using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartController : MonoBehaviour
{
    public GameObject[] green;
    public GameObject[] purple;
    public GameObject pedestal;

    public GameObject tank;

    private void Update()
    {
        CheckHealth();
        CheckPowerup();
    }

    private void CheckHealth()
    {
        if (tank)
        {
            if (tank.GetComponent<PlayerController>().health >= 3)
                green[0].gameObject.SetActive(true);
            else
                green[0].gameObject.SetActive(false);

            if (tank.GetComponent<PlayerController>().health >= 2)
                green[1].gameObject.SetActive(true);
            else
                green[1].gameObject.SetActive(false);

            if (tank.GetComponent<PlayerController>().health >= 1)
                green[2].gameObject.SetActive(true);
            else
                green[2].gameObject.SetActive(false);
        }
        else
        {
            green[2].gameObject.SetActive(false);
            green[1].gameObject.SetActive(false);
            green[0].gameObject.SetActive(false);
        }
    }

    private void CheckPowerup()
    {
        //pedestal.GetComponent<SpriteRenderer>().sprite = tank.GetComponent<PlayerController>().currentPowerupSprite;
        //      ALSO NEED TO MAKE SURE THIS RESIZES THE SPRITE CORRECTLY

        if (tank)
        {
            float timeLeft = tank.GetComponent<PlayerController>().turret.GetComponent<TurretControls>().powerupTimeRemaining;
            float percentLeft = timeLeft / 5f;

            if (percentLeft > 0.83f)
            {
                purple[0].SetActive(true);
                purple[1].SetActive(true);
                purple[2].SetActive(true);
                purple[3].SetActive(true);
                purple[4].SetActive(true);
                purple[5].SetActive(true);
            }
            else if (percentLeft > 0.67f)
            {
                purple[0].SetActive(true);
                purple[1].SetActive(true);
                purple[2].SetActive(true);
                purple[3].SetActive(true);
                purple[4].SetActive(true);
                purple[5].SetActive(false);
            }
            else if (percentLeft > 0.5f)
            {
                purple[0].SetActive(true);
                purple[1].SetActive(true);
                purple[2].SetActive(true);
                purple[3].SetActive(true);
                purple[4].SetActive(false);
                purple[5].SetActive(false);
            }
            else if (percentLeft > 0.33f)
            {
                purple[0].SetActive(true);
                purple[1].SetActive(true);
                purple[2].SetActive(true);
                purple[3].SetActive(false);
                purple[4].SetActive(false);
                purple[5].SetActive(false);
            }
            else if (percentLeft > 0.16f)
            {
                purple[0].SetActive(true);
                purple[1].SetActive(true);
                purple[2].SetActive(false);
                purple[3].SetActive(false);
                purple[4].SetActive(false);
                purple[5].SetActive(false);
            }
            else if (percentLeft > 0)
            {
                purple[0].SetActive(true);
                purple[1].SetActive(false);
                purple[2].SetActive(false);
                purple[3].SetActive(false);
                purple[4].SetActive(false);
                purple[5].SetActive(false);
            }
            else if (percentLeft <= 0)
            {
                purple[0].SetActive(false);
                purple[1].SetActive(false);
                purple[2].SetActive(false);
                purple[3].SetActive(false);
                purple[4].SetActive(false);
                purple[5].SetActive(false);
            }
        }
    }
}
