using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickup : MonoBehaviour
{
    public int reserveRefill;// refills the reserve amount on the UI ammo counter
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Refills guns ammo reserve counter, tops up accordingly to the max amount allowed, and checks to see if reserve count is already X amount which denies player to pick up
    // If it can be picked up the item is destroyed
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Player.GetComponent<Gun>().reserveSize != Player.GetComponent<Gun>().maxReserveSize)
        {
            Player.GetComponent<Gun>().AddAmmo(reserveRefill);
            Destroy(gameObject);
        }
        


    }
}