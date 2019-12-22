using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour
{
    public List<GameObject> powerups;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, powerups.Count);
        GameObject spawn = Instantiate(powerups[index], transform.position, Quaternion.identity);
    }
}
