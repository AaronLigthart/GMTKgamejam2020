using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject spawnPoint;
    private Rigidbody ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        spawnPoint = gameManager.spawnPositon;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        Vector3 spawnPosition = new Vector3(this.spawnPoint.transform.position.x, this.spawnPoint.transform.position.y + transform.localScale.y / 2, this.spawnPoint.transform.position.z) + (Vector3.up * 30);
        transform.SetPositionAndRotation(spawnPosition, this.spawnPoint.transform.rotation);
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;

    }
}
