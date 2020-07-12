using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PachincoManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject spawn;
    public Camera pachincoCamera;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        pachincoCamera.enabled = false;
        ball.transform.SetPositionAndRotation(getRandomStartPosition(), Quaternion.identity);
        
    }

    public Vector3 getRandomStartPosition()
    {
        float randomX = Random.Range(spawn.transform.position.x - radius, spawn.transform.position.x + radius);
        float randomY = Random.Range(spawn.transform.position.y - radius, spawn.transform.position.y + radius);

        Vector3 pos = new Vector3(randomX, randomY, spawn.transform.position.z);
        return pos;
    }

    public void Play()
    {
        pachincoCamera.enabled = true;
        ball.transform.SetPositionAndRotation(getRandomStartPosition(), Quaternion.identity);
        ball.SetActive(true);
    }

    public void Stop()
    {

        Invoke("TurnOffCamera", 1);
    }

    public void TurnOffCamera()
    {
        pachincoCamera.enabled = false;
        ball.SetActive(false);

    }

    // Update is called once per frame
}
