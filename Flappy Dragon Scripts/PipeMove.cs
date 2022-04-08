using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    GameManager GameManager;
    private bool counted;

    private void Start()
    {
        counted = false;
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<GameManager>();
    }

    private void Update()
    {
        transform.Translate(GameManager.moveVector * GameManager.moveSpeedPipe*Time.deltaTime);

        if (transform.position.x<=0f && transform.position.x>-0.5f && counted==false&&!Player.isDead)//when the pipe is over the player and the player is not dead then increase score
        {
            PipeSpawner.GetInstance().ScoreUp();
            SoundManager.PlaySound(SoundManager.Sound.Score);
            counted = true;
            return;
        }

        if (transform.position.x < -5f)//destroyed on leftbound, hardcoded number.
        {
            Destroy(gameObject);
        }
    }
}//class
