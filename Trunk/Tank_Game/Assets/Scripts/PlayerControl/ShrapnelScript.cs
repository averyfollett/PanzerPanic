using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrapnelScript : MonoBehaviour
{
    public float force;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 5), Random.Range(0, 5)) * force);
    }
}
