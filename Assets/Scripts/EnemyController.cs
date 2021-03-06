using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float chaseDistance;

    private Transform target;
    private Vector2 startingPosition;

    PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If player is within certain distance of enemy, enemy should start chasing player
        if (Vector2.Distance(transform.position, target.position) < chaseDistance && Vector2.Distance(transform.position, target.position) > 0.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (playerScript.win)
        {
            speed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.transform.position = startingPosition;
        }
    }
}
