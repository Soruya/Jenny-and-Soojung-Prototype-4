using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = player.direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
