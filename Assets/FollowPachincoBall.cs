using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPachincoBall : MonoBehaviour
{
    public GameObject ball;
    public float offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pointA = this.ball.transform.position; // Position of objectA
        Vector3 pointB = this.transform.position; // Position of objectB
        Vector3 pointC = Vector3.Lerp(pointA, pointB, offset);

        this.transform.position = Vector3.Lerp(this.transform.position, pointC, 0.15f);
        this.transform.position = new Vector3(0, this.transform.position.y, -9);

    }
}
