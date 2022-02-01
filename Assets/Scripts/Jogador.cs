using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public float speed = 10;
    Rigidbody2D rb;
    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKey(up))
            movement = Vector2.up;
        else if(Input.GetKey(down))
            movement = Vector2.down;   
        else 
            movement = Vector2.zero;   
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement*Time.fixedDeltaTime*speed);
    }
}
