using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("ObstaculePrefabs")]
    [SerializeField] GameObject sacoBox;
    [SerializeField] GameObject peraRight, peraLeft;
    [SerializeField] GameObject Barbell;
    [SerializeField] GameObject RingRopes;
    [SerializeField] GameObject Wall;
    [SerializeField] List<GameObject> obstacules = new List<GameObject>();
     [Header("PeraBoxingVariables")]
    [SerializeField] float peraRightMinX, peraRightMaxX;
    [SerializeField] float peraLeftMinX, peraLeftMaxX;
    [SerializeField] float peraMinZ, peraMaxZ;
    [SerializeField] float peraY;
    [Header("SacoBoxingVariables")]
    [SerializeField] float sacoMinX, sacoMaxX;
    [SerializeField] float sacoMinZ, sacoMaxZ;
    [SerializeField] float sacoY;
    [Header("RingRopesVariables")]
    [SerializeField] float ropesX, ropesY;
    [SerializeField] float ropesMinZ, ropesMaxZ;
    [Header("WallsVariables")]
    [SerializeField] float xWallRight, xWallLeft;
    [SerializeField] float zWallMin, zWallMax;
    public void SpawnPeraBoxing(int maxSpawns)
    {
        int canSpawn = Random.Range(0, 2);
        if (canSpawn > 0)
        {
            int spawns = Random.Range(1, maxSpawns);
            for (int i = 0; i < spawns; i++)
            {
                int leftOrRight = Random.Range(0, 2);

                switch (leftOrRight)
                {
                    case 0:
                        Vector3 rightSpawnPos = new Vector3(GetPeraRightX(), peraY, GetPeraZ());
                        GameObject RightPera = ObjectPooling.instance.SpawnFromPool("PeraRight", rightSpawnPos, peraRight.transform.rotation, transform);
                        obstacules.Add(RightPera);
                        break;
                    case 1:
                        Vector3 leftSpawnPos = new Vector3(GetPeraLeftX(), peraY, GetPeraZ());
                        GameObject LeftPera = ObjectPooling.instance.SpawnFromPool("PeraLeft", leftSpawnPos, peraLeft.transform.rotation, transform);
                        obstacules.Add(LeftPera);
                        break;
                }
            }
        }
    }
    public void SpawnSacoBoxing(int maxSpawns)
    {
        int spawns = Random.Range(0, maxSpawns);
        for (int i = 0; i < spawns; i++)
        {
             Vector3 SpawnPos = new Vector3(GetSacoX(), sacoY, GetSacoZ());
             GameObject BoxingSaco = ObjectPooling.instance.SpawnFromPool("Saco",SpawnPos,sacoBox.transform.rotation,transform);
             obstacules.Add(BoxingSaco);
        }
    }
    public void SpawnRingRopes()
    {
        int canSpawn = Random.Range(0, 4);
        if (canSpawn > 2)
        {
            Vector3 SpawnPos = GetRopesSpawnPos();
            GameObject ringRope = ObjectPooling.instance.SpawnFromPool("RingRopes", SpawnPos, RingRopes.transform.rotation, transform);
            obstacules.Add(ringRope);
        }
    }
    
    public void SpawnWall()
    {
        int canSpawn = Random.Range(0, 4);
        if(canSpawn > 1)
        {
            Vector3 SpawnPos = GetWallSpawnPos();
            GameObject WallObstacule = ObjectPooling.instance.SpawnFromPool("Wall", SpawnPos, Wall.transform.rotation, transform);
            obstacules.Add(WallObstacule);
        }
    }
    public float GetPeraRightX()
    {
        float peraRightX = Random.Range(peraRightMinX, peraRightMaxX);
        return peraRightX;
    }
    public float GetPeraLeftX()
    {
        float peraLeftX = Random.Range(peraLeftMinX, peraLeftMaxX);
        return peraLeftX;
    }
    public float GetPeraZ()
    {
        float peraZ = Random.Range(peraMinZ, peraMaxZ);
        return peraZ;
    }

    public float GetSacoX()
    {
        float sacoX = Random.Range(sacoMinX, sacoMaxX);
        return sacoX;
    }
    public float GetSacoZ()
    {
        float sacoZ = Random.Range(sacoMinZ, sacoMaxZ);
        return sacoZ;
    }
    public void DeleteObstacules()
    {
        foreach(GameObject obstacule in obstacules)
        {
            obstacule.SetActive(false);
        }
        obstacules.Clear();
    }
    public Vector3 GetRopesSpawnPos()
    {
        Vector3 SpawnPos = new Vector3(ropesX, ropesY, Random.Range(ropesMinZ, ropesMaxZ));
        return SpawnPos;
    }
    public Vector3 GetWallSpawnPos()
    {
        int leftOrRight = Random.Range(0, 2);
        float x = 0;
        switch (leftOrRight)
        {
            case 0:
                 x = xWallRight;
                break;
            case 1:
                 x = xWallLeft;
                break;
        }

        Vector3 SpawnPos = new Vector3(x, 1.45f, Random.Range(6.5f, -4.7f));
        return SpawnPos;
    }
   
    
}
