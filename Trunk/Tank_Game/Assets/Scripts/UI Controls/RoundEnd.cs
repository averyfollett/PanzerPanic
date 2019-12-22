using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundEnd : MonoBehaviour
{
    public List<GameObject> messages;
    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        messages[0].SetActive(true);
        messages[1].GetComponent<Text>().text = "Player 1's Score: " + gm.player1Score.ToString();
        messages[1].SetActive(true);
        messages[2].GetComponent<Text>().text = "Player 2's Score: " + gm.player2Score.ToString();
        messages[2].SetActive(true);
        StartCoroutine(ShowStats());
    }

    IEnumerator ShowStats()
    {
        yield return new WaitForSeconds(5.0f);
        gm.ResetScores();
        SceneManager.LoadScene("MainMenu");
    }
}
