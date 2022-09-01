using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    gameManager gm;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletVelocity;
    [SerializeField]
    private Transform bulletPosition;

    // Start is called before the first frame update
    void Start()
    {
        gm=GameObject.Find("gameManager").GetComponent<gameManager>();
        
        if(!gm.shootCanceling)
        {
          InvokeRepeating("shoot", 0.5f, 0.7f);
        }
    }

    void Update()
    {
        if(gm.shootCanceling)
        {
            bullet.SetActive(false);
        }
        else
        {
            bullet.SetActive(true);
        }
    }


    public void shoot()
    {
        GameObject bulletSpawn = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3 (0f, 0f, bulletVelocity*Time.deltaTime);
    }
}
