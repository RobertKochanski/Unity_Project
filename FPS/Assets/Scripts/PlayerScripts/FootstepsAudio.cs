using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private bool grounded;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1.0f);

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && grounded)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }

}
