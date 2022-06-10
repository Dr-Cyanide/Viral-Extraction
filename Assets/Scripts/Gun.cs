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

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnPoint = transform.GetChild(0).gameObject;
        canFire = true;

        currentClipAmmo = maxAmmo;
       
    }

    // Update is called once per frame
    void Update()
    {
      
        Gun currentgun = FindObjectOfType<Gun>();
        ammoInfoText.text = currentgun.currentClipAmmo + " / " + currentgun.reserveSize;

        if (currentClipAmmo == 0 && !isReloading)
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
        if (isReloading)
            return;

    } 
    

    public void Shoot()
    {

        if (Input.GetMouseButtonDown(0) && canFire)
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

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);
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
        canFire = true;
    }
    public void AddAmmo(int reserveRefill)
    {
        reserveSize += reserveRefill;

        if (reserveSize > maxReserveSize)
        {
            reserveSize = maxReserveSize;
        }


    }
}