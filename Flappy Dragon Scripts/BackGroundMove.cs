using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{

    [HideInInspector]
    public float speed; //testing the difference between [HideInInspector] and [SerializeField]
    private Rigidbody2D myBody;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        speed = 0.5f;
    }

    private void Update()
    {
        if (transform.position.x < -40f) //hard coded left bound, should instead be a variable above
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(-speed, 0); //-speed, background moves left
    }
}//class
