using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int player1Score = 0;
    public int player2Score = 0;
    public int scoreNeededToWin = 3;
    public AudioClip cheer;

    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        CheckTestKeys();
        CheckWin();
    }

    void CheckTestKeys()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown(KeyCode.Alpha0))
            SceneManager.LoadScene("MainMenu");

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene("Final 1");

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene("Final 2");

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene("Final 3");

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SceneManager.LoadScene("Final 4");
    }

    void CheckWin()
    {
        if (player1Score >= scoreNeededToWin)
        {
            Debug.Log("Player 1 Wins!");
            SceneManager.LoadScene("RoundEnd");
            StartCoroutine(WaitThenMainMenu());
            ResetScores();
        }
        else if (player2Score >= scoreNeededToWin)
        {
            Debug.Log("Player 2 Wins!");
            SceneManager.LoadScene("RoundEnd");
            StartCoroutine(WaitThenMainMenu());
            ResetScores();
        }
    }

    IEnumerator WaitThenMainMenu()
    {
        yield return new WaitForSeconds(5f);
        
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
    }

    public void Respawn()
    {
        audioSource.clip = cheer;
        audioSource.Play();
        StartCoroutine(RespawnWithDelay());
    }

    IEnumerator RespawnWithDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
