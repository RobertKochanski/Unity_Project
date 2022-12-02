using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootsteps : MonoBehaviour
{
    private AudioSource audioSource;
    private bool provoked;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        provoked = GetComponentInParent<EnemyAI>().Provoked();
        isDead = GetComponentInParent<EnemyHealth>().IsDead();

        if (provoked && !isDead)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}
