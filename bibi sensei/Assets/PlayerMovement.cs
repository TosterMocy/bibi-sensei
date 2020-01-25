using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 3f;
    [SerializeField] private float JumpHeight = 10.0f;

    private Rigidbody2D _rigidbody2D;

    private bool isOnGround = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (isOnGround)
            {
                _rigidbody2D.velocity += (Vector2.up*JumpHeight*10f);
                isOnGround = false;
            }
        }

       
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.velocity += (Vector2.right*MovementSpeed);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.velocity += (Vector2.left*MovementSpeed);
        }

        if (!Input.anyKey)
        {
            var rigidbody2DVelocity = _rigidbody2D.velocity;

            rigidbody2DVelocity.x = 0;

        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") ||other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle") )
        {
            isOnGround = true;
        }
    }
    
    
    
}
