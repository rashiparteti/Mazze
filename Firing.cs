using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public Transform muzzle;
    public GameObject muzzlePrefab;
    public float muzzlespeed = 10f;
    public int bulletsPerBurst = 3;
    public float burstDelay = 0.1f;
    public int maxAmmo = 30;
    public float reloadTime = 0.75f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public AudioClip fireSound; // Sound for firing
    public AudioClip reloadSound; // Sound for reloading

    private int currentAmmo;
    private bool isReloading = false;
    private bool isFiring = false;
    private Animator animator;
    private bool isScoped = false;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentAmmo = maxAmmo;
        audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource component to the player
    }

    void Update()
    {
        if (isReloading) return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!isScoped)
            {
                animator.SetBool("Scope", true);
                isScoped = true;
                fpsCam.fieldOfView = 45;
            }
            else
            {
                animator.SetBool("Scope", false);
                isScoped = false;
                fpsCam.fieldOfView = 60;
            }
        }

        if (Input.GetButtonDown("Fire1") && !isFiring)
        {
            StartCoroutine(FireBurst());
        }
    }

    IEnumerator FireBurst()
    {
        isFiring = true;

        for (int i = 0; i < bulletsPerBurst; i++)
        {
            if (currentAmmo > 0)
            {
                Shoot();
                currentAmmo--;
                yield return new WaitForSeconds(burstDelay);
            }
            else
            {
                break;
            }
        }

        isFiring = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        var bullet = Instantiate(muzzlePrefab, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * muzzlespeed;

        PlaySound(fireSound); // Play firing sound
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reload", true);
        PlaySound(reloadSound); // Play reloading sound
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        animator.SetBool("Reload", false);
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public int GetCurrentAmmo() // Method to get current ammo count
    {
        return currentAmmo;
    }

    public bool IsReloading() // Method to check if reloading is in progress
    {
        return isReloading;
    }
}
