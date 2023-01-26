using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionPrefab;

    public float power;
    public float angle;

    float lifetime;
    float XVelocity = 0;
    float YVelocity = 0;
    float elapsedTime = 0;
    float gravity = -9.8f;
    Vector3 startLocation;

    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 5.0f;
        }

        startLocation = transform.position;

        XVelocity = power * Mathf.Cos(angle * Mathf.PI / 180);
        YVelocity = power * Mathf.Sin(angle * Mathf.PI / 180);

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        transform.position = new Vector3(startLocation.x + (XVelocity * elapsedTime), 
            startLocation.y + (YVelocity * elapsedTime) + (gravity/2 * Mathf.Pow(elapsedTime, 2)));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
