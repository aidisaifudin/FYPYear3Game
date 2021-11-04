using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public bool isParking;
    public float waitTime;
    public GameObject youWinPanel;
    public GameObject youLosePanel;



    public void Start()
    {
        isParking = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarPlayer")
        {
            isParking = true;
            Debug.Log("Car touched");
            StartCoroutine(AppearPanel());
        }
        else
        {
            isParking = false;
        }

    }

    //public void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "CarPlayer")
    //    {
    //        isParking = true;
    //        Debug.Log("Car Stayed!");
    //    }
    //    else
    //    {
    //        isParking = false;
    //    }

    //    if(isParking == true)
    //    {
    //        StartCoroutine(AppearPanel());
          
    //    }
        
    //}

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "CarPlayer")
        {
            isParking = false;
            youWinPanel.gameObject.SetActive(false);
        }
    }

    IEnumerator AppearPanel()
    {
        yield return new WaitForSeconds(waitTime);
        youWinPanel.gameObject.SetActive(true);
    }
}
