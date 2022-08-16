using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldCode : MonoBehaviour
{
    public gameManager gm;
    public GameObject shield;


    // Start is called before the first frame update
    void Start()
    {
        gm=GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    void Update()
    {
        if (gm.score == 0)
        {
            shield.SetActive(true);
        }
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gm.shieldScore += 1;
            shield.SetActive(false);
            Invoke("resetScore", 2f);
        }
    }

    private void resetScore()
    {
        gm.shieldScore = 0;
    }
}
