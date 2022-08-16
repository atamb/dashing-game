using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawner : MonoBehaviour
{

    public gameManager gm;
    public GameObject[] prefabMaker;
    public float xPos;
    public float xPosObs;
    public float zPos;
    public int i;
    public GameObject[] coins;
    public GameObject[] obstacles;

    

    void Start()
    {
        InstantiateObjects();
    }

    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag("coin");
        obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        if (gm.HitBool == true || gm.WinBool == true)
        {
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.SetActive(false);
            }
            foreach (GameObject coins in coins)
            {
                coins.SetActive(false);
            }
            zPos = 0;
            InstantiateObjects();
            gm.WinBool = false;
            gm.HitBool = false;

        }
    }

    private void InstantiateObjects()
    {
        Random.InitState(gm.level);
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
