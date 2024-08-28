using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //shooting
    [SerializeField]
    private Rigidbody2D bullet;

    [SerializeField]
    private Transform barrel;

    private float bulletSpeed = 500f;

    //switching between Shotgun and Pistol

    string currentWeaponName;

    //firerate
    private float fireRate = 0.4f;
    private float nextFire = 0f;
    private float fireRateShotgun = 1f;

    //Reload

    private int ammoAmount;

    //Sounds
    [SerializeField] private AudioSource pistolShotSound;
    [SerializeField] private AudioSource pistolReloadSound;
    [SerializeField] private AudioSource shotgunShotSound;
    [SerializeField] private AudioSource shotgunReloadSound;

    private void Start()
    {
        currentWeaponName = gameObject.name.Substring(0, name.IndexOf("_"));
        ammoAmount = 0;
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            WeaponFire(currentWeaponName);
        }

        if (Input.GetKey(KeyCode.R) && tag == "Pistol")
        {
            StartCoroutine(WaitForSecondsPistol());
        }
        if (Input.GetKey(KeyCode.R) && tag == "Shotgun")
        {
            StartCoroutine(WaitForSecondsShotgun());
        }
    }
    private void WeaponFire(string weaponName)
    {
        if (weaponName == "Pistol" && Time.time > nextFire && ammoAmount > 0)
        {
            nextFire = Time.time + fireRate;
            pistolShotSound.Play();
            var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            spawnedBullet.AddForce(barrel.up * bulletSpeed);
            ammoAmount -= 1;
        }
        else if (weaponName == "Shotgun" && Time.time > nextFire && ammoAmount > 0)
        {
            //I lose one ammo
            ammoAmount -= 3;
            shotgunShotSound.Play();
            //Shotgun firerate
            nextFire = Time.time + fireRateShotgun;

            //three bullets are spawned
            for (int i = 0; i <= 2; i++)
            {
                var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);

                switch (i)
                {
                    case 0:
                        spawnedBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f, -90f, 0f));
                        break;
                    case 1:
                        spawnedBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f, 0f, 0f));
                        break;
                    case 2:
                        spawnedBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f, 90f, 0f));
                        break;
                }
            }
        }
    }
    IEnumerator WaitForSecondsPistol()
    {
        pistolReloadSound.Play();
        yield return new WaitForSeconds(1);
        ammoAmount = 12;
    }
    IEnumerator WaitForSecondsShotgun()
    {
        shotgunReloadSound.Play();
        yield return new WaitForSeconds(1);
        shotgunReloadSound.Play();
        yield return new WaitForSeconds(1);
        ammoAmount = 12;
    }
}
