using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 10.0f;
    [SerializeField] private float JumpHeight = 10.0f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementDir;

    private bool isOnGround = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _movementDir=new Vector2(0,0);
    }
    
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (isOnGround)
            {
                _rigidbody2D.velocity = (Vector2.up*JumpHeight);
                isOnGround = false;
            }
        }

       
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.velocity = (Vector2.right*MovementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.velocity = (Vector2.left*MovementSpeed);
        }
        
        _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity,Vector2.zero, 0.3f);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
