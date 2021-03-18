using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    EventSO onSwitchPlayers;
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
    void Start()
    {
        //player2.SetActive(false);
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
            // Debug.Log("Grounded");
            if (jetSO.canJump)
            {
                innerVelocity = jumpForce * Vector3.up;
                // Debug.Log(rb.velocity);
                // Debug.Log("jumppppppppppppppppp");
            }
        }
        else
        {
            jetSO.canJump = false;
            jetSO.grounded = false;
        }
        rb.velocity = innerVelocity;
    }

    public void switchPlayers()
    {
        if (null != player1.gameObject && null != player2.gameObject)
        {
            if (player1.gameObject.activeInHierarchy == true)
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
            // Debug.Log("not NUll");
            onSwitchPlayers.raise();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
        if (collision.gameObject.CompareTag("Enemy"))
            Application.Quit(); // looooooool
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
