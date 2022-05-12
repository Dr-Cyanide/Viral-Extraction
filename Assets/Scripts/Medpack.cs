using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medpack : MonoBehaviour
{
    public float HealAmount;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth += HealAmount;
            if (other.gameObject.GetComponent<PlayerHealth>().playerHealth > 100)
            {
                other.gameObject.GetComponent<PlayerHealth>().playerHealth = 100;   
            }
            Destroy(gameObject);
        }
    }
}
