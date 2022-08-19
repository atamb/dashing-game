using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonCode : MonoBehaviour
{
    public void StarttheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame () 
    {
    Application.Quit ();
    Debug.Log("Game is exiting");
    }
}
