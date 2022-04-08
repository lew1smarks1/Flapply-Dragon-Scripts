using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject skyReference;

    private GameObject spawnedSky;

    [SerializeField]
    private Transform skyPos;

    void Start()
    {
        StartCoroutine(SpawnCloud());
    }

    //Spawns random clouds on top or bottom and sets the speed of the cloud
    IEnumerator SpawnCloud()
    {
        while (true)//forever spawning clouds, never false
        {
            yield return new WaitForSeconds(50f);
            spawnedSky = Instantiate(skyReference);
            spawnedSky.transform.position = skyPos.position;
            spawnedSky.GetComponent<BackGroundMove>().speed = 0.5f;
        }//while loop
    }
}//class
