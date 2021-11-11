using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarTheft : MonoBehaviour
{
    public bool isTouching;
    public GameObject panel;
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        isTouching = false;
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTouching = true;
            StartCoroutine(AppearPanelMsg());
            Debug.Log("Car Parked");

        }
        else
        {
            isTouching = false;
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTouching = false;
        }
    }

    IEnumerator AppearPanelMsg()
    {
        panel.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        panel.gameObject.SetActive(false);
        car.gameObject.SetActive(false);

    }
}
