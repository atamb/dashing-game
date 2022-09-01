using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class coinscript : MonoBehaviour
{
    [SerializeField]
    private gameManager gm;
    [SerializeField]
    private ParticleSystem patlama;
    [SerializeField]
    private GameObject coinModel;
    [SerializeField]
    private AudioSource coinSound;



    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        coinSound=GameObject.Find("coinSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gm.score == 0)
        {
            coinModel.SetActive(true);      
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinModel.SetActive(false);
            patlama.Play();
            gm.score += 1;
            coinSound.Play();
            gm.gold++;
            gm.goldText.text = "= " + gm.gold.ToString();
        }

    }
}
