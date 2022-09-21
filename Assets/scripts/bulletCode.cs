using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCode : MonoBehaviour
{
    gameManager gm;
    Rigidbody rb;
    private float explosionForce;
    private float explosionRadius;
    private void Start() 
    {
        explosionForce = 500;
        explosionRadius = 10;
        rb=GetComponent<Rigidbody>();
        gm=GameObject.Find("gameManager").GetComponent<gameManager>();
        Invoke("DestroyBullets", 0.5f);
    }

    private void DestroyBullets()
    {
        Destroy(this.gameObject);
    }

    private void Update()
     {
        if(gm.gunIndex==4)
        {
            rb.AddExplosionForce(explosionForce,transform.position,explosionRadius);
            transform.localScale= new Vector3(0.16f, 0.18f, 1);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
       if(other.gameObject.tag=="enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
