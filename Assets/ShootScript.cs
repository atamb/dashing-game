using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletVelocity;
    [SerializeField]
    private Transform bulletPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            shoot();
        }
    }

    public void shoot()
    {
        GameObject bulletSpawn = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3 (0f, 0f, bulletVelocity*Time.deltaTime);
    }
}
