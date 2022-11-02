using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Transform player;
    [SerializeField] private float agroRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        timeBtwShots = startTimeBtwShots;
    }

    private void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            Vector2 target = transform.position + ((player.position - transform.position) * moveSpeed * Time.fixedTime);
            rb.MovePosition(target);
        }


        if (timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}