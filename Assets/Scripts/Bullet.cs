using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100.0f;
    public GameObject splatEffect;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        Invoke("DestroySelf", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        string thingHit = collision.gameObject.name;
        Debug.Log("I hit something boss! " + thingHit);

        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(splatEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag != "Player")
        {
            DestroySelf();
        }

        if (collision.gameObject.tag == "Environment")
        {
            DestroySelf();
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
