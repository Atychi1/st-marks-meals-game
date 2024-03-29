using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private bool isRunning = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("IsRunning", false); // Make sure the animation starts with the idle state

        AudioManager audioManager = AudioManager.Instance;
        if (audioManager != null && audioManager.IsPlaying("MenuTheme"))
        {
            audioManager.Stop("MenuTheme");
        }

        audioManager.Play("MainTheme");


    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            isRunning = true;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            isRunning = false;
            animator.SetBool("IsRunning", false);
        }

        // Flip the sprite and animation when running left
        if (Time.timeScale != 0f) // Check if the game is not paused
        {
            if (horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
}

