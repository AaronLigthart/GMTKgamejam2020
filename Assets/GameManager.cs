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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBall()
    {
        var spawnPosition = new Vector3(spawnPositon.transform.position.x, spawnPositon.transform.position.y + ball.transform.localScale.y / 2, spawnPositon.transform.position.z);
        ball.transform.SetPositionAndRotation(spawnPosition, spawnPositon.transform.rotation);
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;

    }
}
