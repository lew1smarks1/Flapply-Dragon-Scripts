using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cloudReference;

    private GameObject spawnedBG;

    [SerializeField]
    private Transform topPos, botPos;

    private int randomIndex;
    private int randomPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCloud());
    }

    //Spawns random clouds in a random interval on top or bottom
    IEnumerator SpawnCloud()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6, 10));

            randomIndex = Random.Range(0, cloudReference.Length);
            randomPos = Random.Range(0, 2);

            spawnedBG = Instantiate(cloudReference[randomIndex]);

            //Top spawn
            if (randomPos == 0)
            {
                spawnedBG.transform.position = topPos.position;
                spawnedBG.GetComponent<CloudMove>().speed = Random.Range(0.8f, 1.3f);
            }
            //Bottom spawn
            else
            {
                spawnedBG.transform.position = botPos.position;
                spawnedBG.GetComponent<CloudMove>().speed = Random.Range(0.8f, 1.3f);
            }
        }//while loop
    }
}
