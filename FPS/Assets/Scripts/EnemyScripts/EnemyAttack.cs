using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth target;

    [SerializeField]
    private AudioClip attackSound;
    private AudioSource audio;

    [SerializeField] 
    private float damage = 10f;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }

        audio.PlayOneShot(attackSound);
        target.GetComponent<DamageDisplay>().ShowDamageImage();
        target.TakeDamage(damage);
    }
}
