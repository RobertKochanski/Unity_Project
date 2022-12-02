using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light light;
    private bool lightOn = false;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightOn = !lightOn;
        }

        if (lightOn)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }
}
