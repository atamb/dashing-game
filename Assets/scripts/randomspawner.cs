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
                obstacle.SetActive(false);
            }
            foreach (GameObject coins in coins)
            {
                coins.SetActive(false);
            }
            foreach (GameObject shield in shields)
            {
                shield.SetActive(false);
            }
            foreach (GameObject bullet in bullets)
            {
                bullet.SetActive(false);
            }
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
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
            int index = Random.Range(0, 11);
            if (index < 4)
            {
                GameObject newCoin = Instantiate(prefabMaker[0], new Vector3(xPos, 0, zPos), Quaternion.identity);
            }
            else if (index < 8)
            {
                GameObject obstacle = Instantiate(prefabMaker[1], new Vector3(xPosObs, 1, zPos), Quaternion.identity);
            }
            else if (index < 9)
            {
                GameObject shield = Instantiate(prefabMaker[2], new Vector3(xPos, 0, zPos), Quaternion.identity);
            }
            else if(index<=11)
            {
                GameObject enemy = Instantiate(prefabMaker[3], new Vector3(xPos, 0, zPos), Quaternion.identity);
            }


        }
    }
}
