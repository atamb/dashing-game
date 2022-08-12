using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawner : MonoBehaviour
{

    public GameObject[] prefabMaker;
    public float xPos;
    public float xPosObs;
    public float zPos;
    public int i;
    

    void Start()
    {
        for (i = 0; i < 10; i++)
        {
            xPos = Random.Range(-1f, 2f);
            xPosObs = Random.Range(-0.25f, 1.85f);
            zPos += 10;
            int index = Random.Range(0, prefabMaker.Length);
            if (index == 0)
            {
                GameObject newCoin = Instantiate(prefabMaker[index], new Vector3(xPos, 0, zPos), Quaternion.identity);
            }
            else
            {
                GameObject obstacle = Instantiate(prefabMaker[index], new Vector3(xPosObs, 1, zPos), Quaternion.identity);
            }


        }
    }
}
