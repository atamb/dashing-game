using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public float score;
    public float shieldScore;
    public bool HitBool;
    public bool WinBool;
    public int level;

    void Start()
    {
        score = 0;
        shieldScore = 0;
        HitBool = false;
        WinBool = false;
    }

}
