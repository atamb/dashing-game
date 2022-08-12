using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class coinscript : MonoBehaviour
{
    public gameManager gm;
    public ParticleSystem patlama;
    public GameObject coinModel;

    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
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
        }

    }
}
