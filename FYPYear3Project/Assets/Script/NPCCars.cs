using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCars : MonoBehaviour
{

    public GameObject losingPanel;
    public bool hitCar;


    // Start is called before the first frame update
    void Start()
    {
        hitCar = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CarPlayer")
        {
            hitCar = true;
            losingPanel.gameObject.SetActive(true);
        }
        else
        {
            hitCar = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "CarPlayer")
        {
            hitCar = false;
            losingPanel.gameObject.SetActive(false);
        }
    }
}
