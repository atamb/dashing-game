using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cubemovement : MonoBehaviour
{

    public gameManager gm;
    private float speed;
    public Vector3 firstPos;
    public Vector3 lastPos;
    private float movespeed;
    public Animator animator;
    public ParticleSystem explosion;


    // Update is called once per frame

    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        speed = 10;
        movespeed = 2;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    void Update()
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

        FallingGround();

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "obstacle":
                speed = 0;
                movespeed = 0;
                explosion.Play();
                StartCoroutine(falling());
                break;

            case "finisher":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    private void FallingGround()
    {
        if (transform.position.y < 0)
        {
            StartCoroutine(fallingdown());
        }
    }

    IEnumerator falling()
    {
        animator.SetTrigger("fall");
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(0, 0.5f, 0);
        gm.score = 0;
        speed = 10;
        movespeed = 2;
    }

    IEnumerator fallingdown()
    {
        movespeed = 0;
        animator.SetBool("fallingDown",true);
        yield return new WaitForSeconds(1);
        movespeed = 2;
        animator.SetBool("fallingDown",false);
        transform.position = new Vector3(0, 0.5f, 0);
        gm.score = 0;
    }
}
