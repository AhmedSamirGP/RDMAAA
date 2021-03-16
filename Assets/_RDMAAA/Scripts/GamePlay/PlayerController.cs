using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(CharacterController), typeof(Rigidbody))]
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
    Rigidbody rb;
    CharacterController controller;
    Animator animator;
    [SerializeField]
    GameObject camPlayer1; 
    [SerializeField]
    GameObject camPlayer2;
    [SerializeField]
    JetPackSO jetSO;
    void Start()
    {
        jetSO.grounded = true;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movement.vector = Vector3.zero;
        playerData.position = this.transform.position;
        player2.gameObject.SetActive(false);
    }

    void Update()
    {

        if (movement.vector.y > 0)
        {
            StartCoroutine(fall());
            jetSO.canJump = false;
        }
        else
            jetSO.canJump = true;
        if (controller.isGrounded)
            jetSO.grounded = true;
        else
            jetSO.grounded = false;

    }
    void FixedUpdate()
    {
        rb.velocity = movement.vector * playerData.speed;
        Debug.Log(rb.velocity);
        playerData.position = this.transform.position;

    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(1);
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }

    [System.Obsolete]
    public void switchPlayers()
    {
        if (null != player1.gameObject && null != player2.gameObject)
        {
            if (player1.gameObject.active == true)
            {
                player1.gameObject.SetActive(false);
                player2.gameObject.SetActive(true);
                camPlayer1.SetActive(false);
                camPlayer2.SetActive(true);
            }
            else
            {
                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(false);
                camPlayer1.SetActive(true);
                camPlayer2.SetActive(false);

            }
            Debug.Log("not NUll");

        }
    }
}
