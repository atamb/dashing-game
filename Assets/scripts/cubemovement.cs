using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cubemovement : MonoBehaviour
{
    
    private float lastFrameFingerPositionX;
    private float moveFactorX;
    [SerializeField] private float movespeed=60;
    public GameObject levelCompleted;
    public GameObject Continue;
    public gameManager gm;
    private float speed;
    public Animator animator;
    public float minusLimit = -1.25f;
    public float positiveLimit = 2.2f;
    public ParticleSystem[] shield;
    [SerializeField] private float ShieldResetTime;
    public ParticleSystem winParticle;
    [SerializeField] private bool over;
    public GameObject road;
    public float zMagnitude;
    public float zPosition;
    public GameObject finish1;
    public GameObject finish2;
    public GameObject finish3;
    private float zfinish1,zfinish2,zfinish3;
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject[] goldScene;
    [SerializeField] private AudioSource crushTheWall;
    [SerializeField] private AudioSource winSound;


    // Update is called once per frame

    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        speed = 10;
        over = false;
        startpositions();
    }

    void FixedUpdate()
    {
        verticalMovement();
    }

    void Update()
    {
        horizontalMovement();
        restrictMovement();
        shieldParticles();
        increaseBulletFrequency();
        screenChanging();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "obstacle":
                StartCoroutine(falling());
                break;

            case "enemy":
                StartCoroutine(falling());
                break;

            case "slower":
                speed=8;
                break;

            case "finisher":
                gm.shootCanceling = true;
                guns[gm.gunIndex].SetActive(false);
                levelCompleted.SetActive(true);
                animator.SetBool("win", true);
                speed = 0;
                movespeed = 0;
                winSound.Play();
                winParticle.Play();
                Invoke("TapToContinue",1f);
                break;

            case "shield":
                ShieldResetTime += 2;
                gm.shieldScore += 1;
                Invoke("resetShieldScore", ShieldResetTime);
                break;
        }
    }

    private void horizontalMovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }

        else if(Input.GetMouseButton(0))
        {
            moveFactorX = (Input.mousePosition.x - lastFrameFingerPositionX)/15;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }

        else if(Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
        float swerveAmount = Time.fixedDeltaTime * movespeed * moveFactorX;
        transform.Translate(swerveAmount,0,0);
    }

    private void verticalMovement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    public void restrictMovement()
    {
        if (transform.position.x > 2.2f)
        {
            transform.position = new Vector3(2.2f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -1.2f)
        {
            transform.position = new Vector3(-1.2f, transform.position.y, transform.position.z);
        }
    }

    private void shieldParticles()
    {
        if (gm.shieldScore == 1)
        {
            shield[0].Play();
            shield[1].Play();
        }

        if (gm.shieldScore == 0)
        {
            shield[0].Stop();
            shield[1].Stop();
        }
    }

    private void resetShieldScore()
    {
        gm.shieldScore = 0;
        ShieldResetTime = 0;
    }

    private void TapToContinue()
    {
        Continue.SetActive(true);
        over = true;
    }

    private void increaseBulletFrequency()
    {
        if(over && gm.gold>=50 && gm.bulletFrequency>0.4 && gm.gunIndex==0)
        {
            goldScene[0].SetActive(true);
            gm.goldSceneOpen=true;
        }

        if((over) && (gm.gold>=100) && !(gm.bulletFrequency>0.4) && (gm.gunIndex == 0))
        {
            goldScene[1].SetActive(true);
            gm.goldSceneOpen = true;
        }
        
    }

    private void screenChanging()
    {
        if (over && !gm.goldSceneOpen && Input.GetMouseButtonDown(0))
        {
            guns[gm.gunIndex].SetActive(true);
            over = false;
            gm.level += 1;
            animator.SetBool("win", false);
            gm.WinBool = true;
            transform.position = new Vector3(0, 0.5f, 0);
            gm.shootCanceling = false;
            gm.score = 0;
            speed = 10;
            movespeed = 2;
            Continue.SetActive(false);
            levelCompleted.SetActive(false);
            gm.objectcount += 1;
            increasepositions();
        }
    }

    private void increasepositions()
    {
            zPosition+=5f;
            zMagnitude+=10f;
            zfinish1+=10f;
            zfinish2+=10f;
            zfinish3+=10f;
            road.transform.localScale=new Vector3(4.11f,transform.localScale.y,zMagnitude);
            road.transform.position= new Vector3(0.7f,0,zPosition);
            finish1.transform.position= new Vector3(finish1.transform.position.x,finish1.transform.position.y,zfinish1);
            finish2.transform.position= new Vector3(finish2.transform.position.x,finish2.transform.position.y,zfinish2);
            finish3.transform.position= new Vector3(finish3.transform.position.x,finish3.transform.position.y,zfinish3);
    }

    private void startpositions()
    {
            zMagnitude=110f;
            zPosition=46.1f;
            zfinish1=103.0889f;
            zfinish2=107.6725f;
            zfinish3=101.5655f;
    }


    IEnumerator falling()
    {
        if (gm.shieldScore==0)
        {
            crushTheWall.Play();
            speed = 0;
            movespeed = 0;
            animator.SetBool("hit", true);
            gm.shootCanceling=true;
            yield return new WaitForSeconds(2);
            gm.HitBool = true;
            animator.SetBool("hit", false);
            transform.position = new Vector3(0, 0.5f, 0);
            gm.shootCanceling=false;
            gm.score = 0;
            speed = 10;
            movespeed = 2;
        }
    }

   



}
