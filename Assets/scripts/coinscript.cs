using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class coinscript : MonoBehaviour
{
    [SerializeField]
    private gameManager gm;
    [SerializeField]
    private ParticleSystem patlama;
    [SerializeField]
    private GameObject coinModel;
    [SerializeField]
    private int gold;

    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        gold = PlayerPrefs.GetInt("goldSaved");
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
            gold+=1;
            PlayerPrefs.SetInt("goldSaved", gold);
        }

    }
}
