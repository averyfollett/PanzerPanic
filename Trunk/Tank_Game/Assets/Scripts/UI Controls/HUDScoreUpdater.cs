using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScoreUpdater : MonoBehaviour
{
    private Text[] scoreText;

    private void Start()
    {
        scoreText = GetComponentsInChildren<Text>();
    }

    private void LateUpdate()
    {
        if (GameManager.instance)
        {
            for (int i = 0; i < scoreText.Length; i++)
            {
                scoreText[i].text = "Blue - " + GameManager.instance.player1Score + ":" +
                    GameManager.instance.player2Score + " - Red";
            }
        }
    }
}
