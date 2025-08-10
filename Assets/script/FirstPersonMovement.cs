using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 6f;
    public bool canJump = true;
    public float jumpForce = 5f;
    private bool isGrounded = true;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (canJump && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
