using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 100f;
    private bool isDead = false;

    [SerializeField] private AudioClip deadAudio;
    [SerializeField] private AudioClip damagedAudio;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();

        if (enemyHealth <= 0)
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTaken();
        enemyHealth -= damage;

        if (!isDead)
        {
            audio.PlayOneShot(damagedAudio);
        }

        if (enemyHealth <= 0 && !isDead)
        {
            audio.PlayOneShot(deadAudio);
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
