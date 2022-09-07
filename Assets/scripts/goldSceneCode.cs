using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldSceneCode : MonoBehaviour
{
    [SerializeField] private GameObject[] goldScene;
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
        goldScene[0].SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
    }
    public void no()
    {
        noButtonSound.Play();
        goldScene[0].SetActive(false);
        gm.goldSceneOpen=false;
    }

     public void GettingFirstGunYes()
     {
        gm.gold-=100;   
        gm.bulletFrequency=0.7f;
        gm.gunIndex+=1;
        yesButtonSound.Play();
        goldScene[1].SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
     }
      public void GettingFirstGunNo()
     {
        noButtonSound.Play();
        goldScene[1].SetActive(false);
        gm.goldSceneOpen=false;
     }
}
