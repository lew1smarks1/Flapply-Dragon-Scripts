using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))//esc to exit game, use buttons + menu next time
        {
            QuitGame();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}//class
