using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKeyboardBehaviour : MonoBehaviour
{

    public LineRenderer line;
    public GameObject ball;
    public GameObject hole;
    private GameManager _gameManager;

    Vector3 ForceDirection = Vector3.forward;
    private void Start()
    {
        _gameManager = GameManager.Instance;
        ball = _gameManager.ball;
        hole = _gameManager.hole;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            ball.GetComponent<Rigidbody>().AddForceAtPosition((ForceDirection) * 50, Vector3.forward * 1000);

        }


        if (Input.GetKey(KeyCode.A))
        {
            if (ForceDirection.x < 2)
            {
                ForceDirection.x += 0.5f;
            }
            if (ForceDirection.z > -2)
            {
                ForceDirection.z -= 0.5f;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (ForceDirection.x > -2)
            {
                ForceDirection.x -= 0.5f;
            }
            if (ForceDirection.z < 2)
            {
                ForceDirection.z += 0.5f;
            }
        }

        line.SetPosition(0, ball.transform.position);
        line.SetPosition(1, ball.transform.position + (ForceDirection * 2));
    }
}
