using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float jumpForce = 500f;
    [SerializeField]
    private GameObject restartMessage;
    [SerializeField]
    private GameObject jumpToStart;
    private Rigidbody2D myBody;
    public static bool isDead = false;
    private string ENEMY_TAG = "Enemy";//tags as variable strings makes for easier + faster coding
    private string BOUNDARY_TAG = "Boundary";
    public event EventHandler OnDied;
    private static Player instance;
    
    public static Player GetInstance()//getting instance of this script to access methods and variables in this class
    {
        return instance;
    }



    private void Awake()
    {
        SoundManager.PlaySound(SoundManager.Sound.StartScreen);
        Time.timeScale = 0; //pauses the game
        jumpToStart.SetActive(true);
        restartMessage.SetActive(false);
        instance = this;
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerJump();
        StartCoroutine(Death());//Coroutine is called all the time during update, should only be called when needed to (after player has lost the game)
        transform.eulerAngles = new Vector3 (0, 0, 2*myBody.velocity.y);//rotation related to the gravity (since gravity changes velocity in y)
    }
     
    
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump")&&!isDead)
        {
            SoundManager.PlaySound(SoundManager.Sound.PlayerJump);
            jumpToStart.SetActive(false);
            Time.timeScale = 1; //Player starts the game by pressing spacebar
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)//if the player hits a "pipe" or boundary, they lose the game
    {
        if (collision.CompareTag(ENEMY_TAG)||collision.CompareTag(BOUNDARY_TAG)&&!isDead)
        {
            GetComponent<Animator>().Play("Player Die");
            myBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            isDead = true;
            SoundManager.PlaySound(SoundManager.Sound.Lose);
        }


    }
    

    IEnumerator Death() 
    {

        if (isDead)
        {
            if (OnDied != null)// this if statement is unused, was testing out Event system, but didn't understand it at the time
            {
                OnDied(this, EventArgs.Empty);
            }
            yield return new WaitForSeconds(1);//allows the death animation to play fully before pausing the game
            isDead = false;
            Score.TrySetNewHighscore(PipeSpawner.GetInstance().GetScore());
            restartMessage.SetActive(true);
            SoundManager.PlaySound(SoundManager.Sound.NewHighscore);
            Time.timeScale = 0;
            Destroy(gameObject); //never gets called
        }
    }

}//class