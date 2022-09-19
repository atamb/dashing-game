using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCode : MonoBehaviour
{
    private void Start() 
    {
        Invoke("DestroyBullets", 0.5f);
    }

    private void DestroyBullets()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag=="enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
