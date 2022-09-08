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
        gm.gold -= 50;
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

     public void yesTo75()
    {
        gm.gold -= 75;
        gm.bulletFrequency-=0.1f;
        yesButtonSound.Play();
        goldScene[2].SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
    }
    public void noTo75()
    {
        noButtonSound.Play();
        goldScene[2].SetActive(false);
        gm.goldSceneOpen=false;
    }
    
    public void GettingSecGunYes()
     {
        gm.gold-=200;   
        gm.bulletFrequency=0.6f;
        gm.gunIndex+=1;
        gm.doublecoin+=1;
        yesButtonSound.Play();
        goldScene[3].SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
     }
    public void GettingSecGunNo()
     {
        noButtonSound.Play();
        goldScene[3].SetActive(false);
        gm.goldSceneOpen=false;
     }
     
     public void yesTo150()
    {
        gm.gold -= 150;
        gm.bulletFrequency-=0.1f;
        yesButtonSound.Play();
        goldScene[4].SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
    }
    public void noTo150()
    {
        noButtonSound.Play();
        goldScene[4].SetActive(false);
        gm.goldSceneOpen=false;
    }

    public void GettingThirdGunYes()
     {
        gm.gold-=350;   
        gm.bulletFrequency=0.6f;
        gm.gunIndex+=1;
        gm.doublecoin+=1;
        yesButtonSound.Play();
        goldScene[5].SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
     }
    public void GettingThirdGunNo()
     {
        noButtonSound.Play();
        goldScene[5].SetActive(false);
        gm.goldSceneOpen=false;
     }

     public void yesTo250()
    {
        gm.gold -= 250;
        gm.bulletFrequency-=0.1f;
        yesButtonSound.Play();
        goldScene[6].SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
    }
    public void noTo250()
    {
        noButtonSound.Play();
        goldScene[6].SetActive(false);
        gm.goldSceneOpen=false;
    }

    public void GettingFourthGunYes()
     {
        gm.gold-=750;   
        gm.bulletFrequency=0.6f;
        gm.gunIndex+=1;
        gm.doublecoin+=1;
        yesButtonSound.Play();
        goldScene[7].SetActive(false);
        gm.goldText.text = "= " + gm.gold.ToString();
        gm.goldSceneOpen=false;
     }
    public void GettingFourthGunNo()
     {
        noButtonSound.Play();
        goldScene[7].SetActive(false);
        gm.goldSceneOpen=false;
     }

}
