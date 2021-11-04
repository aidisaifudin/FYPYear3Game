using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingTrigger : MonoBehaviour
{
    public float timerCountdown = 3.0f; //how long player have to stay in the parking lot
    public bool isPlayerColliding = false; // is the player currently at the location
    public bool isTimer = false; //timer boolean
    public GameObject winPanel;
    public GameObject losePanel;
   




    // Update is called once per frame
    void Update()
    {
        if(isPlayerColliding == true) //collision timer
        {
            isTimer = true;
            timerCountdown -= Time.deltaTime;
            if (timerCountdown <= 0 )
            {
                timerCountdown = 0;
                isTimer = false;
            }
        }
       
    }

    public void OnTriggerEnter(Collider other)//start the collision timer when player enter
    {
        //if(other.gameObject.tag == "Player" )
        //{
        //    Debug.Log("Player Entered");
        //    isPlayerColliding = true;
        //    isTimer = true;
            
        //}
    }

    public void OnTriggerStay(Collider other)//check if player is still at location
    {
        if(other.gameObject.tag == "carPlayer" && isPlayerColliding == true)
        {
            isTimer = true;
            Debug.Log(timerCountdown);
            if(timerCountdown <= 0)
            {
                losePanel.gameObject.SetActive(true);//panel comes out
                isTimer = false;
                //StartCoroutine(HidePanel());//panel close
                
            }
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "carPlayer")
        {
            
            isPlayerColliding = false;
            losePanel.gameObject.SetActive(false);//panel close

        }
    }

    //IEnumerator HidePanel()
    //{
    //    yield return new WaitForSecondsRealtime(2);
    //    winPanel.gameObject.SetActive(false);
       
        
        
        

    //}
}
