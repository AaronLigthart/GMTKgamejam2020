using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public LevelManager levelManager;
    public GameObject ball;
    public GameObject spawnPositon;
    public GameObject hole;
    public GameObject cameraFocusPoint;
    public PachincoManager pachincoManager;
    private Rigidbody ballRigidbody;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI windStrengthText;
    public float distanceToHole;
    public float focusPriority;
    private EventController _eventController;



    // Start is called before the first frame update
    void Start()
    {
        _eventController = EventController.Instance;
        ballRigidbody = ball.GetComponent<Rigidbody>();

        Invoke("LateStart", 0.1f);

    }

    void LateStart()
    {
        levelManager.SpawnLevel(levelManager.levels[0]);
        this.ResetBall();
    }

    public void Update()
    {
        this.UpdateDistanceText();
    }

    public void UpdateDistanceText()
    {
        distanceToHole = (Mathf.Round(Vector3.Distance(ball.transform.position, hole.transform.position) * 10f) / 10f) - 1;
        distanceText.SetText(distanceToHole + " m");
    }

    public void FixedUpdate()
    {
        this.updateFocusPoint();

    }

    public void updateFocusPoint()
    {
        Vector3 pointA = this.ball.transform.position; // Position of objectA
        Vector3 pointB = this.hole.transform.position; // Position of objectB
        Vector3 pointC = Vector3.Lerp(pointA, pointB, focusPriority);

        this.cameraFocusPoint.transform.position = Vector3.Lerp(this.cameraFocusPoint.transform.position, pointC, 0.15f); 

        distanceToHole = (Mathf.Round(Vector3.Distance(ball.transform.position, hole.transform.position) * 10f) / 10f) - 1;
        distanceText.SetText(distanceToHole + " m");
    }

    public void ResetBall()
    {
        ball.GetComponent<Ball>().spawnPoint = this.spawnPositon;
        ball.GetComponent<Ball>().Reset();
        
    }

    public void DoEvent(string eventName)
    {
        print(eventName);
        levelManager.gotoNextLevel();
        print(eventName);
   
        switch (eventName)
        {
            case "smallBall":
                ball.transform.localScale.Set(0.5f, 0.5f, 0.5f);
                ballRigidbody.mass = 0.5f;
                _eventController.ChangeCameraToShaderCall(CAMERA_SHADER.AURA);
                break;

            case "bigBall":
                ball.transform.localScale.Set(2f, 2f, 2f);
                ballRigidbody.mass = 3;
                _eventController.ChangeCameraToShaderCall(CAMERA_SHADER.PIXEL);
                break;
            case "flipScreen":
                ball.transform.localScale.Set(1f, 1f, 1f);
                ballRigidbody.mass = 5;
                Debug.Log(CAMERA_SHADER.DRUNK1);
                _eventController.ChangeCameraToShaderCall(CAMERA_SHADER.DRUNK1);

                break;
            default:
                print("HAHALOl");
                break;
        }
    }

    public void StartPachinco()
    {
        pachincoManager.Play();
    }
}
