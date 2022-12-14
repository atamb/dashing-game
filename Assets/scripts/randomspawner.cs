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
    public GameObject[] shields;
    public GameObject[] bullets;
    public GameObject[] enemies;

    

    void Start()
    {
        gm.objectcount=10;
        InstantiateObjects();
    }

    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag("coin");
        obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        shields = GameObject.FindGameObjectsWithTag("shield");
        bullets = GameObject.FindGameObjectsWithTag("bullet");
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        if (gm.HitBool == true || gm.WinBool == true)
        {
            foreach (GameObject obstacle in obstacles)
            {
                Destroy(obstacle);
            }
            foreach (GameObject coins in coins)
            {
                Destroy(coins);
            }
            foreach (GameObject shield in shields)
            {
                Destroy(shield);
            }
            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet);
            }
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
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
        for (i = 0; i < gm.objectcount; i++)
        {
            xPos = Random.Range(-1f, 2f);
            xPosObs = Random.Range(-0.25f, 1.85f);
            zPos += 10;
            int index = Random.Range(0, 35);
            if (index < 14)
            {
                GameObject newCoin = Instantiate(prefabMaker[0], new Vector3(xPos, 0, zPos), Quaternion.identity);
            }
            else if (index < 28)
            {
                GameObject obstacle = Instantiate(prefabMaker[1], new Vector3(xPosObs, 1, zPos), Quaternion.identity);
            }
            else if (index < 29)
            {
                GameObject shield = Instantiate(prefabMaker[2], new Vector3(xPos, 0, zPos), Quaternion.identity);
            }
            else if(index<=35)
            {
                GameObject enemy = Instantiate(prefabMaker[3], new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
            }


        }
    }
}
