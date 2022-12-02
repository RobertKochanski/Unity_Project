using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ammo;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField]
    private AmmoType ammoType;
    [SerializeField]
    private int amountPickUp = 10;

    [SerializeField]
    private AudioSource audioSource;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, amountPickUp);

            audioSource.PlayOneShot(audioSource.clip);

            Destroy(gameObject);
            Destroy(transform.parent.gameObject, 3.0f);
        }
    }

}
