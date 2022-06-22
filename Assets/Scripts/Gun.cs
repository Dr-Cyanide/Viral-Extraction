using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bulletSpawnPoint;
    public bool canFire;
    public float rateOfFire;
    public TextMeshProUGUI ammoInfoText;
    public GameObject ReloadText;

    public int currentClipAmmo;
    public int maxAmmo = 15;
    public int reserveSize = 25;
    public int maxReserveSize = 25;

    public float reloadTime = 1.5f;
    public bool isReloading;

    // Checks that the player can shoot, and that clip ammo and max ammo are full on start
    void Start()
    {
        bulletSpawnPoint = transform.GetChild(0).gameObject;
        canFire = true;

        currentClipAmmo = maxAmmo;
       
    }

    // Update is called once per frame for the ammuntion counter UI, if the player can reload or shoot, and displays a message if there is 0 ammo in the guns clip
    void Update()
    {
      
        Gun currentgun = FindObjectOfType<Gun>(); //ammunition counter UI
        ammoInfoText.text = currentgun.currentClipAmmo + " / " + currentgun.reserveSize;

        if (currentClipAmmo == 0 && !isReloading)// Displays reload message
        {
            ReloadText.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.R)&& !isReloading)
        {
            ReloadText.SetActive(false);
            StartCoroutine(Reload());
        }
        Shoot();

        if (currentClipAmmo == 0)
        {
            canFire = false;
            return;
        }
        if (currentClipAmmo == 15)
        {
            canFire=true;
        }
        if (isReloading)
            return;

    } 
    
    //Shooting function with ammo taken away after each shot while making sure the player can't shoot and reload at the same time
    public void Shoot()
    {

        if (Input.GetMouseButtonDown(0) && canFire && !isReloading)
        {
            StartCoroutine(FireRate());
        }

        IEnumerator FireRate()
        {
            canFire = false;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            yield return new WaitForSeconds(rateOfFire);
            canFire = true;
            currentClipAmmo--;
        }
    }
    //reload function, checks how much ammo is in clip and reserve and tops up clip with needed amount for max from reserve
    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);//after the reload time the script checks if max ammo in clip is low and loads it to max from reserve accurately
        if(reserveSize != 0 && currentClipAmmo < maxAmmo)
        {
            if (reserveSize > maxAmmo - currentClipAmmo)
            {
                reserveSize = reserveSize - (maxAmmo - currentClipAmmo);
                currentClipAmmo = maxAmmo;
            }
            else
            {
                currentClipAmmo = currentClipAmmo + reserveSize;
                reserveSize = 0;
            }
        }
       
        isReloading = false;
    }
    //Ammunition refill from ammo pick ups/collectable, ensures reserve is topped up correctly and cannot be overfilled above X amount
    public void AddAmmo(int reserveRefill)
    {
        reserveSize += reserveRefill;

        if (reserveSize > maxReserveSize)
        {
            reserveSize = maxReserveSize;
        }


    }
}