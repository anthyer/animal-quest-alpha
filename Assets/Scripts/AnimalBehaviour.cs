using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalBehaviour : MonoBehaviour
{
    protected GameManager gameManager;
    protected Vector3 move;
    protected Vector3 gravity;
    protected bool isGrounded;
    protected bool isJumping;
    protected float rotationSpeed = 1400;
    protected float horizontalInput;

    float startingJumpStrenght;
    float startingSpeed;

    [SerializeField] protected Rigidbody playerRb;
    [SerializeField] protected Animator animalAnim;

    public float JumpStrenght { get; protected set; }
    public float Speed { get; protected set; }

    protected virtual void Start()
    {
        gameManager = GameManager.instance;

        JumpStrenght = startingJumpStrenght;
        Speed = startingSpeed;
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameManager.isGameActive)
        {
            gameManager.CheckForPaused();
        }
    }

    protected virtual void FixedUpdate()
    {
        HandleMovement();
        HandleJump();

        if (isJumping)
        {
            playerRb.AddForce(new Vector3(0, JumpStrenght, 0), ForceMode.Impulse);
            isJumping = false;
        }
    }

    protected virtual void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        var movementPlane = new Vector3(playerRb.velocity.x, 0, 0);

        if (movementPlane.magnitude < Speed && gameManager.isGameActive && !gameManager.paused)
        {
            move = new Vector3(horizontalInput * Speed * Time.deltaTime, 0, 0);
            animalAnim.SetFloat("Speed_f", 1);
        }

        if (horizontalInput != 0 && gameManager.isGameActive && !gameManager.paused && isGrounded)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
            moveDirection.Normalize();
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            playerRb.transform.rotation = Quaternion.RotateTowards(playerRb.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animalAnim.SetFloat("Speed_f", 0);
        }

        playerRb.velocity = new Vector3(move.x, playerRb.velocity.y, playerRb.velocity.z);
    }

    protected virtual void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && gameManager.isGameActive && !gameManager.paused)
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Collided with endgame");

            if (GameManager.coinsCollected > 9)
            {
                gameManager.GameOver();
            }

            else
            {
                StartCoroutine(gameManager.ShowMessage(("Collect all the stars first"), 3.0f));
            }
        }
    }
}
