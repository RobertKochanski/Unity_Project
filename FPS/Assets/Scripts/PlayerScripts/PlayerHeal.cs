using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField]
    private float heal;
    [SerializeField]
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var healed = FindObjectOfType<PlayerHealth>().CureDamage(heal);
            if (healed != -1)
            {
                audioSource.PlayOneShot(audioSource.clip);

                Destroy(gameObject);
                Destroy(transform.parent.gameObject, 1.0f);
            }
        }
    }
}
