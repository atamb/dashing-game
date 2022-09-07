using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCode : MonoBehaviour
{

    Rigidbody rb;
    gameManager gm;
    private float shooted;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private AudioSource shootSound;
    Collider boxCollider;


    void Start()
    {
        Transform health = transform.Find("health");
        transform.rotation= Quaternion.Euler(0,180,0);
        rb=GetComponent<Rigidbody>();
        gm=GameObject.Find("gameManager").GetComponent<gameManager>();
        boxCollider=gameObject.GetComponent<BoxCollider>();
    }


     private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag=="bullet" && shooted<4)
        {
            shootSound.Play();
            health.SetActive(true);
            healthBar.SetActive(true);  
            shooted+=1;
            switch(gm.gunIndex)
            {
                case 0:
                health.transform.localScale =new Vector3(health.transform.localScale.x-0.25f,health.transform.localScale.y,health.transform.localScale.z);         
                break;

                case 1:
                health.transform.localScale =new Vector3(health.transform.localScale.x-0.4f,health.transform.localScale.y,health.transform.localScale.z);    
                break;
            }
        }

        if(other.gameObject.tag=="obstacle")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            animator.SetBool("shot",true);
            Invoke("Destroy",1f);
            gm.gold+=5;
            gm.goldText.text = "= " + gm.gold.ToString();
        }
        
        if(other.gameObject.tag=="Player")
        {
            animator.SetBool("swordHit",true);
        }
    }

    private void FixedUpdate() 
    {
        if(shooted==4 && gm.gunIndex==0)
        {
            boxCollider.enabled=false;
            animator.SetBool("shot",true);
            health.SetActive(false);
            Invoke("Destroy",1f);
            shooted=0;
            gm.gold+=2;
            gm.goldText.text = "= " + gm.gold.ToString();
        }

        if(shooted==3 && gm.gunIndex==1)
        {
            boxCollider.enabled=false;
            animator.SetBool("shot",true);
            health.SetActive(false);
            Invoke("Destroy",1f);
            shooted=0;
            gm.gold+=2;
            gm.goldText.text = "= " + gm.gold.ToString();
        }

    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    
}
