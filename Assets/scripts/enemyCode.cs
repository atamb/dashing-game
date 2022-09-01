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
    [SerializeField] private GameObject enemyGun;
    [SerializeField] private AudioSource shootSound;

    void Start()
    {
        Transform health = transform.Find("health");
        transform.rotation= Quaternion.Euler(0,180,0);
        rb=GetComponent<Rigidbody>();
        gm=GameObject.Find("gameManager").GetComponent<gameManager>();
    }


     private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag=="bullet" && shooted<3)
        {
            shooted+=1;
            health.transform.localScale =new Vector3(health.transform.localScale.x-0.4f,health.transform.localScale.y,health.transform.localScale.z);
            shootSound.Play();
            health.SetActive(true);
            healthBar.SetActive(true);           
        }

        if(collision.gameObject.tag=="obstacle")
        {
            gm.gold+=5;
        }
    }

    private void Update() 
    {
        if(shooted==3)
        {
            animator.SetBool("shot",true);
            health.SetActive(false);
            enemyGun.SetActive(false);
            Invoke("Destroy",1f);
            shooted=0;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gm.gold+=2;
            gm.goldText.text = "= " + gm.gold.ToString();
        }

    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    
}
