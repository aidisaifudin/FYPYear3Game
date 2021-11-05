using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public GameObject passenger;
    public GameObject destination;
    public Collider passengerCollider;
    public bool passengerNotInTaxi;
    public GameObject AidiCar;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        AidiCar = GameObject.FindGameObjectWithTag("Player");
        TaxiManager taxi = GetComponent<TaxiManager>();
        passengerCollider = GetComponent<Collider>();
        passengerNotInTaxi = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (passengerNotInTaxi)
        {
            passengerCollider.enabled = !enabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GetComponent<TaxiManager>().passengerInTaxi == true)
        {
            {
                passenger.transform.SetParent(p: null);
                passenger.SetActive(true);
                passengerNotInTaxi = true;
            }
        }
    }
}
