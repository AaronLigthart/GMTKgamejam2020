using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotOnGround : MonoBehaviour
{

    public Transform clubArea;
    private GameManager _gameManager;
    private GameObject ballObject;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        ballObject = _gameManager.ball;
    }
    void Update()
    {
        Vector3 x = clubArea.position;
        x.y = ballObject.transform.position.y;
        transform.position = x;
    }
}
