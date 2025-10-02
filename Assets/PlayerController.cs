using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public InputAction playerMovement;
    public InputAction playerJumps;
    Vector2 moveDir;
    public float moveSpeed = 5f;
    public Rigidbody rb;
    public Animator animator;
    public float maxSpeed;
    public float debugValue;


    public Transform groundCheck;
    public bool isGrounded;
    float groundDistance = 0.5f;
    public LayerMask groundMask;

    public InputSystem_Actions playerInputManager;

    public float jumpForce;

    private void OnEnable()
    {
        playerMovement.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(moveDir.x * moveSpeed, 0));
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        debugValue = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Velocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("isGrounded", isGrounded);
        moveDir = playerMovement.ReadValue<Vector2>();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce),ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        if (rb.linearVelocity.x < 0 && rb.linearVelocity.magnitude > 1)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, Quaternion.identity.w);
        }
        else if (rb.linearVelocity.x > 0 && rb.linearVelocity.magnitude > 1)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, Quaternion.identity.w);
        }
    }
}
