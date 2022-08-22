using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCode : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation= Quaternion.Euler(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag=="bullet")
        {
            animator.SetBool("shot",true);
            Invoke("Destroy",1f);
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    
}
