using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject spawnPosition;
    private Rigidbody ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        spawnPosition = GameObject.FindGameObjectWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        Vector3 spawnPosition = new Vector3(this.spawnPosition.transform.position.x, this.spawnPosition.transform.position.y + transform.localScale.y / 2, this.spawnPosition.transform.position.z);
        transform.SetPositionAndRotation(spawnPosition, this.spawnPosition.transform.rotation);
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;

    }
}
