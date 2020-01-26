using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BotMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Transform Player;
    public  float movementSpeed = 3f;
    public float jumpHeight = 10f;
    private bool isOnGround = true;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        transform.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player != null)
        {
          
            if (Player.position.x <= transform.position.x +   Random.Range(1, 4))
            {
                rb.velocity += (Vector2.left*movementSpeed);
            }
            if (Player.position.x >= transform.position.x + Random.Range(1, 4)) 
            {
                rb.velocity += (Vector2.right*movementSpeed);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Ground"))
        {
            Debug.Log(other);
            Player = other.transform;
            gameObject.layer = 9;
        }
    }
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player") )
        {
            Debug.Log("Collision");
            rb.velocity += (Vector2.up*jumpHeight*10);

        }
    }
}
