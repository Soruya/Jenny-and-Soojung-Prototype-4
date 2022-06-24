using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health = 100;

    public float playerSpeed = 10f;
    public Rigidbody2D rb;

    Vector2 movement;

    public GameObject bulletPrefab;
    public Vector2 direction;

    void Start()
    {

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Debug.Log("horizontal: " + movement.x + " vertical: " + movement.y);

        if (movement.x != 0 || movement.y != 0)
        {
            direction = movement;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
