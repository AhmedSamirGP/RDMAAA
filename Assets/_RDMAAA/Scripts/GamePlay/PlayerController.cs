using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public GameObject player1;
    [SerializeField]
    public GameObject player2;
    [SerializeField]
    PlayerDataSO playerData;
    [SerializeField]
    Vector3SO movement;
    Animator animator;
    [SerializeField]
    GameObject camPlayer1;
    [SerializeField]
    GameObject camPlayer2;
    [SerializeField]
    JetPackSO jetSO;
    bool isGrounded;
    [SerializeField]
    float jumpForce = 10.0f;
    Rigidbody rb;
    [SerializeField]
    float speed = 10;
    Vector3 innerVelocity;
    [SerializeField]
    EventSO death;
    List<GameObject> grounds = new List<GameObject>();
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        jetSO.canJump = false;
        jetSO.canJet = false;
        jetSO.grounded = isGrounded;
        animator = GetComponent<Animator>();
        movement.vector = Vector3.zero;
        playerData.position = this.transform.position;
    }

    void Update()
    {
        //Debug.Log(controller.isGrounded ? "GROUNDED" : "NOT GROUNDED");
        innerVelocity = movement.vector * speed;
        innerVelocity.y = rb.velocity.y;
        playerData.position = this.transform.position;

        if (isGrounded)
        {
            jetSO.grounded = true;
            jetSO.canJet = false;
            // Debug.Log("Grounded");
            if (jetSO.canJump)
            {
                innerVelocity = jumpForce * Vector3.up;
            }
        }
        else
        {
            jetSO.canJump = false;
            jetSO.grounded = false;
        }
        rb.velocity = innerVelocity;
    }

    public void SwitchPlayers()
    {
        if (null != player1.gameObject && null != player2.gameObject)
        {
            if (player1.gameObject.activeInHierarchy == true)
            {
                player2.SetActive(true);
                camPlayer2.SetActive(true);
                camPlayer1.SetActive(false);
                player1.SetActive(false);
            }
            else
            {
                player1.SetActive(true);
                camPlayer1.SetActive(true);
                camPlayer2.SetActive(false);
                player2.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            grounds.Add(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            death.Raise();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounds.Remove(collision.gameObject);
            if (grounds.Count == 0)
            {
                isGrounded = false;
            }
        }
    }
    private void OnEnable()
    {
        grounds.Clear();
    }
}
