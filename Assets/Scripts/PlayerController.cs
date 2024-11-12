using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int playerHP = 1;
    private bool isAlive = true;

    public GameObject[] guns;

    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {

        }
        else transform.Rotate(new Vector3(0, 0, 2f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public void RecountHP(int amount)
    {
        playerHP += amount;

        if (playerHP <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        playerRb.velocity = new Vector2(0, 15f);
        print("Player is dead");
        isAlive = false;
    }
}