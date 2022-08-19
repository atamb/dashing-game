using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public float score;
    public float shieldScore;
    public bool HitBool;
    public bool WinBool;
    public int level;
    public float objectcount;

    void Start()
    {
        level = 1;
        score = 0;
        shieldScore = 0;
        HitBool = false;
        WinBool = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}
