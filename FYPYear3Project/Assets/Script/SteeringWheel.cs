using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    private bool Wheelbeingheld = false;
    public RectTransform Wheel;
    private float WheelAngle = 0f;
    private float LastWheelAngle = 0f;
    private Vector2 center;
    public float MaxSteerAngle = 200f;
    public float ReleaseSpeed = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
