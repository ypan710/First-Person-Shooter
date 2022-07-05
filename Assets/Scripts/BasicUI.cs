using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
   void OnGUI()
    {
        // function called every frame after everything else renders
        // Parameters: position X, pos y, width, height, text label
        if (GUI.Button(new Rect(10, 10, 40, 20), "Test")) 
        {
            Debug.Log("Test button");
        }
    }
}
