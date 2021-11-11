using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class CarUserController : MonoBehaviour
{
    private CarController m_Car;//The car we want to use

    private void Awake()
    {
        m_Car = GetComponent<CarController>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float handbrake = Input.GetAxis("Jump");
       // m_Car.HandleSteering(h,v,v,handbrake);
    }
}
