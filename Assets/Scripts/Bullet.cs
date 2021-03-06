using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public PlayerScript player;

    public float maxTravelDistance;
    Vector3 startPos;

    
    void Start()
    {
        startPos = gameObject.transform.position;
        player = FindObjectOfType<PlayerScript>();
        rb.velocity = player.direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(startPos, gameObject.transform.position) >= maxTravelDistance)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //destroys and deal damage if hit enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().playEnemyHit();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        //bullet destroyed upon hitting wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
