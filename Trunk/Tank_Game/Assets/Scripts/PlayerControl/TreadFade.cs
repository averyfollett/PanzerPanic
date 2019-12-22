using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadFade : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r,
            GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 
            GetComponent<SpriteRenderer>().color.a - Time.deltaTime);
        if (GetComponent<SpriteRenderer>().color.a == 0)
            Destroy(gameObject);
    }
}
