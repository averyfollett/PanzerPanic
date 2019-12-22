using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowExact : MonoBehaviour
{
    public Transform target;
    public float offsetX;
    public float offsetY;
    public float centerOffset;

    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY, transform.position.z) - (target.transform.up * centerOffset);
    }
}
