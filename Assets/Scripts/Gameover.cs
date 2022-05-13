using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    private bool dead = false;

    private void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Return) && dead == true)
            {
                SceneManager.LoadScene(Application.loadedLevel);
                dead = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape) && dead == true)
            {
                Application.Quit();
            }
        }
    }

    public void restart()
    {
        dead = true;
    }

}
