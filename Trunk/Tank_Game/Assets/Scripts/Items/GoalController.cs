using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public int playerId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("ball detect");
            if (playerId == 0)
            {
                GameManager.instance.player2Score++;
            }
            if (playerId == 1)
            {
                GameManager.instance.player1Score++;
            }
            GameManager.instance.Respawn();
        }
    }
}
