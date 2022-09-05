using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldSceneCode : MonoBehaviour
{
    [SerializeField] private GameObject goldScene;
    gameManager gm;
    private void Start() 
    {
        gm=GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    public void yes()
    {
        gm.gold-=50;
        gm.bulletFrequency-=0.1f;
        goldScene.SetActive(false);
    }
    public void no()
    {
        goldScene.SetActive(false);
    }
}
