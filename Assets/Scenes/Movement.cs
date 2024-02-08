using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float jumpHeight = 1f;
    public Rigidbody2D rb;
    public LayerMask groundLayer;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void Start()
    {
        
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = moveSpeed + 5;

                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = 10;
            }

            else if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = moveSpeed + 5;
                
                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = 10;
            }

            else if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }

        }

        else if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        
    }
}
