using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Transform Player;
    public  float movementSpeed = 3f;
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
            
            if (Player.position.x <= transform.position.x + 2f)
            {
                rb.velocity += (Vector2.left*movementSpeed);
            }
            if( Player.position.x >= transform.position.x+2f)
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
}
