using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldSceneCode : MonoBehaviour
{
    [SerializeField] private GameObject goldScene;
    gameManager gm;
    [SerializeField] private AudioSource yesButtonSound;
    [SerializeField] private AudioSource noButtonSound;
    private void Start() 
    {
        gm=GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    public void yes()
    {
        gm.gold-=50;
        gm.bulletFrequency-=0.1f;
        yesButtonSound.Play();
        goldScene.SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
    }
    public void no()
    {
        noButtonSound.Play();
        goldScene.SetActive(false);
        gm.goldSceneOpen=false;
    }
}
