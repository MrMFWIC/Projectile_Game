using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    CanvasManager cm;
    Rigidbody2D rb;

    public float power;
    public float angle;
    public float damage;

    void Start()
    {
        cm = GetComponent<CanvasManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
}
