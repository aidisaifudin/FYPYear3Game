using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingTrigger : MonoBehaviour
{
    public float timerCountdown = 3.0f; //how long player have to stay in the parking lot
    public bool isPlayerColliding = false; // is the player currently at the location
    public GameObject winPanel;

    // Update is called once per frame
    void Update()
    {
        if(isPlayerColliding == true) //collision timer
        {
            timerCountdown -= Time.deltaTime;
            if(timerCountdown < 0)
            {
                timerCountdown = 0;
            }
        }
        Debug.Log(isPlayerColliding);
    }

    public void OnTriggerEnter(Collider other)//start the collision timer when player enter
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered");
            isPlayerColliding = true;
        }
    }

    public void OnTriggerStay(Collider other)//check if player is still at location
    {
        if(other.gameObject.tag == "Player" && isPlayerColliding == true)
        {
            Debug.Log(timerCountdown);
            if(timerCountdown <= 0)
            {
                winPanel.gameObject.SetActive(true);//panel comes out
                Time.timeScale = 0;//pause real time
                //panel close
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            isPlayerColliding = false;
            winPanel.gameObject.SetActive(false);//panel close

        }
    }

    IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(2);
        winPanel.gameObject.SetActive(false);

    }
}
