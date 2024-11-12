using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float runSpeed = 15f;
    private int direction = 1;

    [SerializeField] private int enemyHP = 5;
    private int enemyDamage = 1;

    public SpriteRenderer sprite;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(runSpeed * direction, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            Flip();
        else if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerController>().RecountHP(-enemyDamage);
    }
    private void Flip()
    {
        sprite.flipX = !sprite.flipX;
        direction *= -1;
    }
}