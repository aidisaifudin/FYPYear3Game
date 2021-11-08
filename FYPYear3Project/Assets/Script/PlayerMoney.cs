using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public int money;
    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMoney(int increaseMoney)
    {
        money += increaseMoney;
    }
    public void SubtractMoney(int decreaseMoney)
    {
        if (money - decreaseMoney < 0)
        {
            Debug.Log("No money");
        }
        else
        {
            money -= decreaseMoney;
        }
    }
}
