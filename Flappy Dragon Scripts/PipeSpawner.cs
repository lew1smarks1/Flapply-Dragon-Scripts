using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float spawnTime;
    private float spawnTimeMax = 4f;
    private int score = 0;
    private int halfscore = 0;
    private static PipeSpawner instance;
    private bool is22=true;
    private bool is69=true;
    public int GetScore()
    {
        return score;
    }
    public static PipeSpawner GetInstance()
    {
        return instance;
    }

    public void ScoreUp()
    {
        halfscore++;
        if (halfscore % 2 == 0)//whenever the score was counted, it counted itself twice so I made it so that the score counted once every 2 scores counted
        {
            score++;
        }
        if (score==22 && is22)
        {
            SoundManager.PlaySound(SoundManager.Sound.Over100);
            is22 = false;
        }
        if (score==69 && is69)
        {
            SoundManager.PlaySound(SoundManager.Sound.Over200);
            is69 = false;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnPipe());//starts spawning pipes
    }

    private void CreatePipe(float x, float y)
    {
        Transform Pipe1 = Instantiate(GameAssets.GetInstance().Pipe1);
        Pipe1.position = new Vector3(0f, -8.24f, 1);//again hardcoded numbers should be variables instead
        Pipe1.position += new Vector3(x, y, 0);

        Transform Pipe2 = Instantiate(GameAssets.GetInstance().Pipe2);
        Pipe2.position = new Vector3(0f, 9.23f, 1);//hardcoded numbers again
        Pipe2.position += new Vector3(x, y, 0);

    }

    IEnumerator SpawnPipe()//infinitely spawns pipes
    {
            while (spawnTime != spawnTimeMax) //spawns "pipes" at an interval of spawnTime which increases toa limit of spawnTimeMax
            {
                spawnTime = spawnTimeMax;
                CreatePipe(20f, Random.Range(-3f, 2f));
                yield return new WaitForSeconds(spawnTime);
                spawnTime = 0;
                spawnTimeMax -= 0.05f * spawnTimeMax;
                if (spawnTimeMax < 0.8f)
                {
                    spawnTimeMax = 0.8f;
                }
            }
        
    }
}//class
