using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;

    private int direction = 1;
    private SpriteRenderer sprite;

    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = playerMovement.direction;
        sprite.flipX = direction < 0;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject _bullet = Instantiate(bullet);
            _bullet.transform.position = transform.position;
            _bullet.transform.rotation = Quaternion.Euler(0, 0, (direction > 0 ? 0f : 180f));
        }
    }
}
