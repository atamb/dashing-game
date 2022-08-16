using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cubemovement : MonoBehaviour
{

    public GameObject levelCompleted;
    public GameObject Continue;
    public gameManager gm;
    private float speed;
    public Vector3 firstPos;
    public Vector3 lastPos;
    private float movespeed;
    public Animator animator;
    public float minusLimit = -1.25f;
    public float positiveLimit = 2.2f;
    public ParticleSystem[] shield;
    public ParticleSystem winParticle;
    private bool over;




    // Update is called once per frame

    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        speed = 10;
        movespeed = 2;
        over = false;
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
        screenChanging();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "obstacle":
                StartCoroutine(falling());
                break;

            case "slower":
                speed=8;
                break;

            case "finisher":
                levelCompleted.SetActive(true);
                animator.SetBool("win", true);
                speed = 0;
                movespeed = 0;
                winParticle.Play();
                Invoke("TapToContinue",1f);
                break;
        }
    }

    private void horizontalMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            firstPos = Camera.main.ScreenToWorldPoint(pos);

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            lastPos = Camera.main.ScreenToWorldPoint(pos);
            Vector3 dif = lastPos - firstPos;
            transform.position += new Vector3(dif.x, 0f, 0f) * Time.deltaTime * movespeed;
        }
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

    private void TapToContinue()
    {
        Continue.SetActive(true);
        over = true;
    }

    private void screenChanging()
    {
        if (over && Input.GetMouseButtonDown(0))
        {
            over = false;
            gm.level += 1;
            animator.SetBool("win", false);
            gm.WinBool = true;
            transform.position = new Vector3(0, 0.5f, 0);
            gm.score = 0;
            speed = 10;
            movespeed = 2;
            Continue.SetActive(false);
            levelCompleted.SetActive(false);
        }
    }


    IEnumerator falling()
    {
        if (gm.shieldScore==0)
        {
            speed = 0;
            movespeed = 0;
            animator.SetBool("hit", true);
            yield return new WaitForSeconds(2);
            gm.HitBool = true;
            animator.SetBool("hit", false);
            transform.position = new Vector3(0, 0.5f, 0);
            gm.score = 0;
            speed = 10;
            movespeed = 2;
        }
    }

   



}
