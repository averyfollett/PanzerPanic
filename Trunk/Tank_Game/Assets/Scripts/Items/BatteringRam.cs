using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteringRam : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
