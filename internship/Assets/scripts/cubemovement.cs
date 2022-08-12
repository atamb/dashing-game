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

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "obstacle":
                speed = 0;
                movespeed = 0;
                StartCoroutine(falling());
                break;

            case "finisher":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    IEnumerator falling()
    {
        animator.SetTrigger("fall");
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(0, 3, 0);
        gm.score = 0;
        speed = 10;
        movespeed = 2;
    }
}
