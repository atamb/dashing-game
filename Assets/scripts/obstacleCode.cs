using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleCode : MonoBehaviour
{
    public gameManager gm;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gm.shieldScore == 1)
        {
            rb.AddForce(0, 200, 1500);
        }
    }
}
