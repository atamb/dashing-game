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
    public bool goldSceneOpen;
    public int level;
    public float objectcount;
    public Text goldText;
    public float bulletFrequency;
    public int gunIndex;
    public int doublecoin;
    [SerializeField] private GameObject pistol;

    void Start()
    {
        doublecoin=1;
        bulletFrequency=0.7f;
        level = 1;
        score = 0;
        gunIndex = 0;
        shieldScore = 0;
        HitBool = false;
        WinBool = false;
        shootCanceling = false;
        goldText.text = "= " + gold.ToString();
    }

    void Update()
    {
        if(gunIndex == 1)
        {
            pistol.SetActive(false);
        }
    }

}
