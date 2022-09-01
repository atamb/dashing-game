using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public float score;
    public float gold;
    public float shieldScore;
    public bool HitBool;
    public bool WinBool;
    public bool shootCanceling;
    public int level;
    public float objectcount;
    public Text goldText;

    void Start()
    {
        level = 1;
        score = 0;
        shieldScore = 0;
        HitBool = false;
        WinBool = false;
        shootCanceling = false;
        goldText.text = "= " + gold.ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}
