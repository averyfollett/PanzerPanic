using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDamage : MonoBehaviour
{
    public Sprite[] damagedSprites;
    private int damageLevel;

    private void Start()
    {
        damageLevel = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        damageLevel++;
        DamageBlock();
    }

    private void DamageBlock()
    {
        if (damagedSprites.Length > damageLevel)
            GetComponent<SpriteRenderer>().sprite = damagedSprites[damageLevel];
    }
}
