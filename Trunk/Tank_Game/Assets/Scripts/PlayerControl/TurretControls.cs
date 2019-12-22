using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TurretControls : MonoBehaviour
{
    public GameObject ammo, explosiveAmmo, snipeShot, turret, parentTank;
    public float ammoSpeed;
    public bool powered, doubleShot, explosiveShot, sniping, rocket;
    public float turnSpeed;
    public float ammoSpawnDistance;
    public int playerId;
    public int powerLimit = 3;
    public int shotKnockback = 100;
    public AudioClip fireSound;
    public float powerupTimeRemaining;
    public string currentPowerup;
    public Sprite defaultTurret, doubleshotTurret, ricochetTurret, explosiveTurret;

    private float turnRate;
    private bool fire, canFire;
    private Player player;
    private AudioSource audioSource;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }

    void Start()
    {
        canFire = true;
        powered = doubleShot = explosiveShot = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckInput();

        CheckTurretArt();

        if (powerupTimeRemaining > 0)
            powerupTimeRemaining -= Time.deltaTime;
    }

    void CheckInput()
    {
        GetInput();
        ProcessInput();
    }

    private void CheckTurretArt()
    {
        if (currentPowerup == "doubleshot")
        {
            turret.GetComponent<SpriteRenderer>().sprite = doubleshotTurret;
        }
        else if (currentPowerup == "explosive")
        {
            turret.GetComponent<SpriteRenderer>().sprite = explosiveTurret;
        }
        else if (currentPowerup == "ricochet")
        {
            turret.GetComponent<SpriteRenderer>().sprite = ricochetTurret;
        }
        else
        {
            turret.GetComponent<SpriteRenderer>().sprite = defaultTurret;
        }
    }

    private void GetInput()
    {
        turnRate = player.GetAxis("Turret");
        fire = player.GetButtonDown("Fire");
    }

    public void ProcessInput()
    {
        if(turnRate != 0.0f)
        {
            transform.Rotate(0.0f, 0.0f, -turnRate * turnSpeed);
        }

        if(fire && canFire)
        {
            if(powered)
            {
                powerLimit--;
                if(powerLimit == 0)
                {
                    powered = doubleShot = explosiveShot = false;
                    powerLimit = 3;
                }
            }
            else if (explosiveShot)
            {
                GameObject temp = Instantiate(explosiveAmmo, transform.position + (transform.up * ammoSpawnDistance), transform.rotation);
                temp.GetComponent<AmmoControl>().explosive = true;

                audioSource.clip = fireSound;
                audioSource.Play();
            }
            else if (doubleShot)
            {
                StartCoroutine(DoubleShot());
            }
            else if (sniping)
            {
                transform.Find("Sniper").gameObject.SetActive(false);
                GameObject temp = Instantiate(snipeShot, transform.position + (transform.up * ammoSpawnDistance), transform.rotation);
                sniping = false;
                currentPowerup = "";
                audioSource.clip = fireSound;
                audioSource.Play();
            }
            else if (rocket)
            {
                GameObject temp = Instantiate(snipeShot, transform.position + (transform.up * ammoSpawnDistance), transform.rotation);
                audioSource.clip = fireSound;
                audioSource.Play();
            }
            else
            {
                GameObject temp = Instantiate(ammo, transform.position + (transform.up * ammoSpawnDistance), transform.rotation);
                audioSource.clip = fireSound;
                audioSource.Play();
            }
            canFire = false;
            StartCoroutine(WaitToFire());
            parentTank.GetComponent<Rigidbody2D>().AddForce(-transform.up * shotKnockback);
        }
    }

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(.5f);
        canFire = true;
    }

    IEnumerator DoubleShot()
    {
        audioSource.clip = fireSound;

        GameObject temp = Instantiate(ammo, transform.position + (transform.up * ammoSpawnDistance), transform.rotation);
        audioSource.Play();

        yield return new WaitForSeconds(0.15f);

        GameObject temp2 = Instantiate(ammo, transform.position + (transform.up * ammoSpawnDistance), transform.rotation);
        audioSource.Play();
    }
}