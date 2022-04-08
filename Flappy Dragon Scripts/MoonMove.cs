using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMove : MonoBehaviour
{
    GameManager GameManager;

    private void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<GameManager>();
    }

    private void Update()
    {
        transform.Translate(-GameManager.moveVector * GameManager.moveSpeedMoon * Time.deltaTime);
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
