using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject spawnPositon;
    public GameObject hole;
    private Rigidbody ballRigidbody;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI windStrengthText;
    public float distanceToHole;



    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        this.UpdateDistanceText();
    }

    public void UpdateDistanceText(){
        distanceToHole = (Mathf.Round(Vector3.Distance(ball.transform.position, hole.transform.position) * 10f) / 10f)-1;
        distanceText.SetText(distanceToHole + " m");
    }
    public void ResetBall()
    {
        ball.GetComponent<Ball>().Reset();
    }
}
