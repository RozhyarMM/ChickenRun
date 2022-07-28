using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    bool Generatemap = true;
    public GameObject mapTile;
    int nextMapTile = 16;

    public GameObject[] ObsObj;
    int nextObsObj = 4;

    public GameObject Pickup;
    int nextPickup;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine()); 
        StartCoroutine(ObstacleRoutine()); 
        StartCoroutine(CoinRoutine()); 
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator SpawnRoutine()
    {
        while (Generatemap)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(mapTile, new Vector3(0,0,nextMapTile), Quaternion.identity);
            nextMapTile += 15;
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator ObstacleRoutine()
    {
        while (Generatemap)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(ObsObj[Random.Range(0,2)], new Vector3(Random.Range(0,2), 0, nextObsObj), Quaternion.identity);
            Instantiate(ObsObj[Random.Range(0,2)], new Vector3(Random.Range(-1,1), 0, nextObsObj), Quaternion.identity);
            nextObsObj += Random.Range(1, 5);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CoinRoutine()
    {
        while (Generatemap)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(Pickup, new Vector3(Random.Range(0, 2), 0, nextPickup), Quaternion.identity);
            Instantiate(Pickup, new Vector3(Random.Range(-1, 1), 0, nextPickup), Quaternion.identity);
            nextPickup += Random.Range(1, 3);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
