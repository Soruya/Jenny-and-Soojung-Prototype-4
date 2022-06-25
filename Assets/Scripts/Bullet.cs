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
        if (Vector3.Distance(startPos, gameObject.transform.position) > maxTravelDistance)
        {
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //destroys and deal damage if hit enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
