using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Text textfield1;
    public Text textfield2;
    private bool won = false;
    public GameObject character;
    public GameObject gameover;
    public Camera player;
    public Camera lose;

    private void OnTriggerEnter(Collider win)
    {
        if (win.gameObject.tag == "Player")
        {
            player.enabled = false;
            lose.enabled = true;
            textfield1.gameObject.SetActive(true);
            textfield2.gameObject.SetActive(true);
            won = true;
            character.SetActive(false);

        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && won == true)
        {
            Application.Quit();
        }
    }



}
