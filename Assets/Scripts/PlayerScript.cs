using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float fullHealth = 200f;
    public float health;
    public float playerSpeed = 10f;
    public Rigidbody2D rb;

    public Vector2 startPos;

    Vector2 movement;

    public GameObject bulletPrefab;
    public Vector2 direction;

    float playerScale;

    public bool win;

    void Start()
    {
        health = fullHealth;
        startPos = transform.position;
        win = false;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!(movement.x == 0 && movement.y == 0))
        {
            direction = movement;
            //Debug.Log("direction x: " + direction.x + " direction y: " + direction.y);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        
    }

    void FixedUpdate()
    {
        //scale player
        playerScale = health / fullHealth;
        gameObject.transform.localScale = new Vector3(playerScale, playerScale, playerScale);
        //player movement
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if player hits enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthChange(-20);
        }
        if (collision.gameObject.CompareTag("Health"))
        {
            HealthChange(50);
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            win = true;
            playerSpeed = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }

    void HealthChange(int num)
    {
        if ((health + num) < fullHealth && (health + num) > 0)
        {
            health = health + num;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            /*transform.position = startPos;
            health = fullHealth;*/
        }
    }
}
