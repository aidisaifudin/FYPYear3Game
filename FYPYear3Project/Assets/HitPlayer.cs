using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPlayer : MonoBehaviour
{

    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Car hit");
        }
    }
}
