using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int maxHealth;
    public AudioClip bounceSound;
    public int playerId;
    public GameObject shrapnel;
    public GameObject turret;
    public int health;
    public Sprite currentPowerupSprite;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("cooooo");
        if (collision.gameObject.layer == 8 || collision.gameObject.tag == "Player")
        {
            audioSource.clip = bounceSound;
            audioSource.Play();
        }
        if (collision.gameObject.tag == "Ammo")
        {
            health -= 1;

            if (health <= 0)
            {
                if (GameManager.instance)
                {
                    if (playerId == 0)
                        if (SceneManager.GetActiveScene().name != "Level 4")
                            GameManager.instance.player2Score++;
                    if (playerId == 1)
                        if (SceneManager.GetActiveScene().name != "Level 4")
                            GameManager.instance.player1Score++;
                    GameManager.instance.Respawn();
                }
                else
                    Debug.Log("need gamemanager instance");
                Destroy(turret);
                Destroy(gameObject);
                Instantiate(shrapnel, transform.position, Quaternion.identity);
            }

            GetComponentInChildren<SpriteRenderer>().material.color = new Color(maxHealth / health, maxHealth / health, maxHealth / health, 1f);
            Camera.main.GetComponent<CameraShake>().TriggerShake();
        }
    }
}
