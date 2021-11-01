using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiManager : MonoBehaviour
{
    public Passenger passenger;
    
    // Start is called before the first frame update
    void Start()
    {
        passenger = FindObjectOfType<Passenger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
