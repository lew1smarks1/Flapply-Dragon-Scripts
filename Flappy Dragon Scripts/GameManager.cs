using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
    //tried to use singleton, I now understand use of singleton and their usability in saving and carrying data between scenes
    //though these values in the actual game are not used
{
    public float moveSpeedPipe = 1.0f;
    //public float moveSpeedCloud = 1.0f;
    public float moveSpeedBackground = 1.0f;
    public float moveSpeedMoon = 1.0f;
    public Vector3 moveVector;

}//class
