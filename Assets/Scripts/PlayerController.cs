using JetBrains.Annotations;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed, moveSpeed, jumpForce, groundCheckRadius, horizontalInput;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded == true)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        Vector3 velocity = rb.linearVelocity;

        float targetVelX = horizontalInput * moveSpeed;

        float newVelX = Mathf.MoveTowards(velocity.x, targetVelX, 50f * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector3(Mathf.Clamp(newVelX, -maxSpeed, maxSpeed), velocity.y, 0f);
    }

    private void Jump()
    {

        
        Vector3 velocidadeLinear = rb.linearVelocity;

        velocidadeLinear.y = 0;

        rb.linearVelocity = velocidadeLinear;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
}
