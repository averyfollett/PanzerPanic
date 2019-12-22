using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(FlashBlock());
    }

    IEnumerator FlashBlock()
    {
        GetComponent<SpriteRenderer>().material.color *= new Color(0.95f, 0f, 0f);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f);
    }
}
