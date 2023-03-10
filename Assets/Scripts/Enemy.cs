using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected Animator anim;

    public float moveSpeed = 5.0f;
    public float direction = -1f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            anim.SetTrigger("Death");
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
