using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    /*
     * 0:Explosive 
     * 1:SpeedBoost 
     * 2:Ricochet 
     * 3:Double Shot 
     * 4:Energy Shield 
     * 5:Sniper Shot
     * 6:Battering Ram
     * 7:Rocket Assist
     */
    public int powerType;
    public float speedBoostAcceleration;
    public float speedBoostMaxSpeed;
    public AudioClip sound;
    public GameObject ricochetPrefab;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().currentPowerupSprite = GetComponent<SpriteRenderer>().sprite;
            if(col.gameObject.name == "Tank1")
            {
                GameObject.Find("UIStart").transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                GameObject.Find("UIStart").transform.GetChild(4).transform.localScale = new Vector3(.33f, .33f, 1);
            }
            else
            {
                GameObject.Find("UIStart (1)").transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                GameObject.Find("UIStart (1)").transform.GetChild(4).transform.localScale = new Vector3(.33f, .33f, 1);
            }
            switch (powerType)
            {
                case 0:
                    col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().powered = true;
                    col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().explosiveShot = true;
                    col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().currentPowerup = "explosive";
                    Destroy(gameObject);
                    break;
                case 1:
                    audioSource.clip = sound;
                    audioSource.Play();
                    StartCoroutine(SpeedBoost(col));
                    GetComponent<SpriteRenderer>().enabled = false;
                    break;
                case 2:
                    audioSource.clip = sound;
                    audioSource.Play();
                    StartCoroutine(Ricochet(col));
                    GetComponent<SpriteRenderer>().enabled = false;
                    break;
                case 3:
                    audioSource.clip = sound;
                    audioSource.Play();
                    StartCoroutine(DoubleShot(col));
                    GetComponent<SpriteRenderer>().enabled = false;
                    break;
                case 4:
                    audioSource.clip = sound;
                    audioSource.Play();
                    StartCoroutine(EnergyShield(col));
                    GetComponent<SpriteRenderer>().enabled = false;
                    break;
                case 5:
                    audioSource.clip = sound;
                    audioSource.Play();
                    col.gameObject.GetComponent<PlayerController>().turret.transform.Find("Sniper").gameObject.SetActive(true);
                    col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().sniping = true;
                    Destroy(gameObject);
                    break;
                case 6:
                    audioSource.clip = sound;
                    audioSource.Play();
                    col.transform.Find("BatteringRam").gameObject.SetActive(true);
                    Destroy(gameObject);
                    break;
                case 7:
                    audioSource.clip = sound;
                    audioSource.Play();
                    StartCoroutine(RocketAssist(col));
                    GetComponent<SpriteRenderer>().enabled = false;
                    break;
            }
        }
    }

    IEnumerator SpeedBoost(Collider2D col)
    {
        float acceleration = col.gameObject.GetComponent<PlayerMovement>().acceleration;
        float maxSpeed = col.gameObject.GetComponent<PlayerMovement>().maxSpeed;
        col.gameObject.GetComponent<PlayerMovement>().acceleration = speedBoostAcceleration;
        col.gameObject.GetComponent<PlayerMovement>().maxSpeed = speedBoostMaxSpeed;
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().powerupTimeRemaining = 5f;
        yield return new WaitForSeconds(5);
        Debug.Log("returning acceleration to " + acceleration);
        Debug.Log("returning maxSpeed to " + maxSpeed);
        col.gameObject.GetComponent<PlayerMovement>().acceleration = acceleration;
        col.gameObject.GetComponent<PlayerMovement>().maxSpeed = maxSpeed;
        Destroy(gameObject);
    }

    IEnumerator Ricochet(Collider2D col)
    {
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().currentPowerup = "ricochet";
        GameObject previousAmmo = col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().ammo;
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().ammo = ricochetPrefab;
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().powerupTimeRemaining = 5f;
        yield return new WaitForSeconds(5);
        Debug.Log("returning ammo to " + previousAmmo.name);
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().ammo = previousAmmo;
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().currentPowerup = "";
        Destroy(gameObject);
    }

    IEnumerator DoubleShot(Collider2D col)
    {
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().currentPowerup = "doubleshot";
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().doubleShot = true;
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().powerupTimeRemaining = 5f;
        yield return new WaitForSeconds(5);
        Debug.Log("doubleshot done");
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().doubleShot = false;
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().currentPowerup = "";
        Destroy(gameObject);
    }

    IEnumerator EnergyShield(Collider2D col)
    {
        col.gameObject.GetComponent<PlayerController>().turret.transform.Find("Shield").gameObject.SetActive(true);
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().powerupTimeRemaining = 5f;
        yield return new WaitForSeconds(5);
        Debug.Log("energy shield done");
        col.gameObject.GetComponent<PlayerController>().turret.transform.Find("Shield").gameObject.SetActive(false);
        Destroy(gameObject);
    }

    IEnumerator RocketAssist(Collider2D col)
    {
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().rocket = true;
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().powerupTimeRemaining = 5f;
        yield return new WaitForSeconds(5);
        Debug.Log("rocket assist done");
        col.gameObject.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().rocket = false;
        Destroy(gameObject);
    }
}
