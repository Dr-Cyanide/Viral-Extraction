using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickup : MonoBehaviour
{
    public int reserveRefill;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Player.GetComponent<Gun>().reserveSize != Player.GetComponent<Gun>().maxReserveSize)
        {
            Player.GetComponent<Gun>().AddAmmo(reserveRefill);
            Destroy(gameObject);
        }
        


    }
}