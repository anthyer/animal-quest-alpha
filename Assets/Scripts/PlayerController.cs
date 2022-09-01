using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody rb;

    Vector3 move;

    float horizontalInput;

    [SerializeField] float gravityModifier;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpStrenght;
    [SerializeField] float speed;

    [SerializeField] bool isGrounded;
    [SerializeField] bool isJumping;

    private void Awake()
    {
        Physics.gravity *= gravityModifier;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameManager.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameManager.isGameActive)
        {
            gameManager.CheckForPaused();
        }
        
        HandleMovement();    
        HandleJump();
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector3(move.x, rb.velocity.y, rb.velocity.z);

        if (isJumping)
        {
            rb.AddForce(new Vector3(0, jumpStrenght, 0), ForceMode.Impulse);
            isJumping = false;
        }
    }

    void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        var movementPlane = new Vector3(rb.velocity.x, 0, 0);

        if (movementPlane.magnitude < speed && gameManager.isGameActive && !gameManager.paused)
        {
            move = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
        }

        if (horizontalInput != 0 && gameManager.isGameActive && !gameManager.paused && isGrounded)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
            moveDirection.Normalize();
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && gameManager.isGameActive && !gameManager.paused)
        {            
            isGrounded = false;
            isJumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }
}
