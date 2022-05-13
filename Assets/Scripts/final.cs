using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour
{
    public GameObject exit;

    private void OnTriggerEnter(Collider final)
    {
        if (final.gameObject.tag == "Player")
        {
            exit.SetActive(true);
        }
    }
}
