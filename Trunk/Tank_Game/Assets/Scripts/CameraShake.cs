using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeMagnitude = 0.7f;
    public float dampingSpeed = 1f;
    public float shakeLength = 2f;

    private Transform transform;
    private float shakeDuration = 0f;
    private Vector3 initialPosition;

    private void Awake()
    {
        if (transform == null)
            transform = GetComponent(typeof(Transform)) as Transform;
    }

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    private void FixedUpdate()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = shakeLength;
    }
}
