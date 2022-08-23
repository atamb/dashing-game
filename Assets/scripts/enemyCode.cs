using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCode : MonoBehaviour
{

    public Animator animator;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation= Quaternion.Euler(0,180,0);
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag=="bullet")
        {
            rb.AddForce(0, 100, 500);
            animator.SetBool("shot",true);
            Invoke("Destroy",2f);
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    
}
