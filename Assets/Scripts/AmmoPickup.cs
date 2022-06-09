using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int AmmoAmmount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Gun>().reserveSize += AmmoAmmount;
            if (other.gameObject.GetComponent<Gun>().reserveSize > 25)
            {
                other.gameObject.GetComponent<Gun>().reserveSize = 25;
            }
            Destroy(gameObject);
        }
    }

}
