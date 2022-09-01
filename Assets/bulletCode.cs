using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCode : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag=="enemy")
        {
            gameObject.SetActive(false);
        }

        if(other.gameObject.name=="bulletDestroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
