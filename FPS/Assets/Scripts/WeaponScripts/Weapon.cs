using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private TextMeshProUGUI ammoText;

    [SerializeField] private Ammo ammo;
    [SerializeField] private AmmoType ammoType;

    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 30f;
    [SerializeField] private float timeBetweenShots = 0.5f;

    private AudioSource audioSource;

    private bool canShoot = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    public void OnEnable()
    {
        StartCoroutine(ShootDelay(0.5f));
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if (ammo.GetCurrentAmmo(ammoType) > 0)
        {
            audioSource.PlayOneShot(audioClip);
            ammo.ReduceCurrentAmmo(ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
        }

        yield return new WaitForSeconds(timeBetweenShots);

        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        else
        {
            return;
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(impact, 0.1f);
    }

    IEnumerator ShootDelay(float time)
    {
        canShoot = false;

        yield return new WaitForSeconds(time);

        canShoot = true;
    }

    private void DisplayAmmo()
    {
        ammoText.text = $"Ammo: {ammo.GetCurrentAmmo(ammoType)}";
        if (ammo.GetCurrentAmmo(ammoType) == 0)
        {
            ammoText.color = Color.red;
        }
        else
        {
            ammoText.color = Color.green;
        }
    }
}
