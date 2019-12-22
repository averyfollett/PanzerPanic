using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShot : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private float timeAlive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive == 10)
            Destroy(gameObject);
    }
}
