using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoControl : MonoBehaviour
{
    public GameObject explosion, redDot;
    public bool instantDestroy, explosive, bouncy;
    public LayerMask collisionMask;
    public float speed;
    public float maxSpeed;
    public int maxBounces;

    private Rigidbody2D rb;
    private int bounceCount;
    private float timeAlive;

    private void Start()
    {
        bounceCount = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;
        

        if (bouncy)
        {
            if (bounceCount > maxBounces)
            {
                Debug.Log("ammo reached " + bounceCount + " bounce and was destroyed");
                DestroyAmmo();
            }
            if (timeAlive > 10f)
            {
                Debug.Log("ammo was alive for 10 seconds and was destroyed");
                DestroyAmmo();
            }
        }
    }

    public void DestroyAmmo()
    {
        GameObject temp = Instantiate(redDot, transform.position, Quaternion.identity) as GameObject;
        if(explosive)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (instantDestroy)
        {
            Debug.Log("ammo was destroyed because it collided with a wall and instant destroy was enabled");
            DestroyAmmo();
        }
        if (bouncy && collision.gameObject.layer == 8)
            bounceCount++;
    }
}
