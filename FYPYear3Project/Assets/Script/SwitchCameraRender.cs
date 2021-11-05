using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraRender : MonoBehaviour
{
    enum RenderModeStates { camera, overlay, world };
    RenderModeStates m_RenderModeStates;

    Canvas m_Canvas;

    // Use this for initialization
    void Start()
    {
        m_Canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //Press the space key to switch between render mode states
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState();
        }
    }

    void ChangeState()
    {
        switch (m_RenderModeStates)
        {
            case RenderModeStates.camera:
                m_Canvas.renderMode = RenderMode.ScreenSpaceCamera;
                m_RenderModeStates = RenderModeStates.overlay;
                break;

            case RenderModeStates.world:
                m_Canvas.renderMode = RenderMode.WorldSpace;
                m_RenderModeStates = RenderModeStates.camera;

                break;
        }
    }
}
