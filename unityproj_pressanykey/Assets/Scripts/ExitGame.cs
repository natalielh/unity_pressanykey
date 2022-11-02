using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{

#if !UNITY_WEBGL
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // press ESC to quit the application
            Debug.Log("ESC key detected, quitting application...");
            Application.Quit();
        }
    }

#endif

}
