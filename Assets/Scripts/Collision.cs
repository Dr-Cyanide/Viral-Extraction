using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public int level = 0;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //level = whatlevel;
            //SceneManager.GetSceneByName(whatlevel);
            SceneManager.LoadScene(level);
        }
    }
    
}