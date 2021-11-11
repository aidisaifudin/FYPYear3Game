using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform cameras;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;


    void Start()
    {
        cameras = Camera.main.transform;
        startPosition = cameras.localPosition;
        initialDuration = duration;
    }

    void Update()
    {
        if(shouldShake)
        {
            if(duration > 0)
            {
                cameras.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                cameras.localPosition = startPosition;
            }
        }
    }





    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            shouldShake = true;
            Debug.Log("Car hit");
        }
    }

    
    
}
