using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class DoubleShot : MonoBehaviour
{
    public GameObject bullet;
    int count = 3;

    private Player player;
    private int playerid;

    void Start()
    {
        playerid = GameObject.Find("TurretJoint").GetComponent<TurretControls>().playerId;
        player = ReInput.players.GetPlayer(playerid);
    }
    
    void Update()
    {
        if(player.GetButtonDown("fire"))
        {
            count--;
            GameObject temp = Instantiate(bullet, transform.position + transform.up, transform.rotation);
            if (count < 1)
                GameObject.Find("TurretJoint").GetComponent<TurretControls>().enabled = true;
                enabled = false;
        }
    }
}
