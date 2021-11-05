using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiManager : MonoBehaviour
{
    public GameObject passenger;
    public bool passengerInTaxi;
    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        passengerInTaxi = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(passengerInTaxi)
        {
            //passenger.transform.SetParent(this.transform);
            Destroy(passenger);
            Debug.Log("Gone");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            passengerInTaxi = true;
        }
    }
}
