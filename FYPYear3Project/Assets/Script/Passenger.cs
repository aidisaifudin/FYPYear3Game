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
    public GameObject passenger2;

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

    }

    private void OnTriggerEnter(Collider other)
    {
    if (other.gameObject.tag == "Player")
        {
            Debug.Log("Passenger is out");
            passenger2.SetActive(true);
            //passenger.transform.SetParent(p: null);
        }
    }
}
