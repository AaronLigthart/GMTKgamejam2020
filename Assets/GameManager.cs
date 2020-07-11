using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject spawnPositon;
    private Rigidbody ballRigidbody; 
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    public void ResetBall()
    {
        ball.GetComponent<Ball>().Reset();
    }
}
