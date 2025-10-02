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

    bool isGrounded;
    public float groundDistance;
    public LayerMask groundMask;

    public InputSystem_Actions playerInputManager;

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
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        debugValue = rb.linearVelocity.magnitude;
        animator.SetFloat("Velocity", rb.linearVelocity.magnitude);
        moveDir = playerMovement.ReadValue<Vector2>();

        if (Keyboard.current[UnityEngine.InputSystem.Key.Space].wasPressedThisFrame == true && isGrounded)
        {
            rb.AddForce(new Vector2(moveDir.x * moveSpeed, 0));
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
