using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]
    RigidbodyFirstPersonController controller;
    [SerializeField]
    private List<Camera> cameras;
    [SerializeField]
    private float zoomedIn = 40f;
    [SerializeField]
    private float zoomedOut = 60f;
    [SerializeField]
    private float zoomedInSens = 1f;
    [SerializeField]
    private float zoomedOutSens = 2f;

    private bool zoomed = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomed == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomed = true;
        foreach (var camera in cameras)
        {
            camera.fieldOfView = zoomedIn;
            controller.mouseLook.XSensitivity = zoomedInSens;
            controller.mouseLook.YSensitivity = zoomedInSens;
        }
    }

    private void ZoomOut()
    {
        zoomed = false;
        foreach (var camera in cameras)
        {
            camera.fieldOfView = zoomedOut;
            controller.mouseLook.XSensitivity = zoomedOutSens;
            controller.mouseLook.YSensitivity = zoomedOutSens;
        }
    }
}
