using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 direction;
    public float speed;
    public AudioClip onHitWall;
    public AudioClip onHitPlayer;
    AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
        do{
            direction = new Vector2(1, Random.Range(-1.5f, 1.5f));
        } while (Mathf.Abs(direction.y) <= 0.1f);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction*speed*Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.GetComponent<Jogador>())
        {
            direction.x *= -1;
            direction.y = Random.Range(-1.5f, 1.5f);
            audioSource.clip = onHitPlayer;
            audioSource.Play();
        } else {
            direction.y *= -1;
            audioSource.clip = onHitWall;
            audioSource.Play();
        }
    }
}
