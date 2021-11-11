using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earnings : MonoBehaviour
{
    public Text earningText;

    int earnings = 0;

    public static Earnings endOfTrip;

    private void Awake()
    {
        endOfTrip = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        earningText.text = " Earnings" + earnings.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EarnMoney()
    {
        earnings += 300;
        earningText.text = " Earnings" + earnings.ToString();
    }
}
