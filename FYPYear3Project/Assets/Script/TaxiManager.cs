using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiManager : MonoBehaviour
{
    public GameObject passenger;
    public bool passengerInTaxi;
    public bool passengerNotInTaxi;
    
    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        passengerInTaxi = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(passengerInTaxi)
        {
            passenger.transform.SetParent(this.transform);
            passenger.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Passenger"))
        {
            passengerInTaxi = true;
        }
    }
}
