using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

    [HideInInspector]
    public float speed;
    private Rigidbody2D myBody;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x < -15f)//Again, hardcoded. Should be a variable
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(-speed, 0);//negative speed since it moves to the left
    }
}//class
