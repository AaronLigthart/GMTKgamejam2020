using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForceBehaviour : MonoBehaviour
{

    Vector3 StartPosition, ProgressPosition, EndPosition;
    Vector3 mOffset;
    float mZCoord;

    public LineRenderer line;
    public GameObject ball;
    Vector3 targetPos;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameManager.Instance;
        ball = _gameManager.ball;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = transform.position - GetMouseWorldPos();
        }
        if (Input.GetMouseButton(0))
        {
            targetPos = GetMouseWorldPos() + mOffset;
            targetPos.y = transform.position.y;

            line.SetPosition(0, ball.transform.position);
            line.SetPosition(1, ball.transform.position + targetPos);
            line.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {

            line.gameObject.SetActive(false);
            ball.GetComponent<Rigidbody>().AddForceAtPosition(-(ball.transform.position + targetPos) * 10,Vector3.Normalize(ball.transform.position + targetPos) * 1000);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousPos);
    }


}
