using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubBehaviour : MonoBehaviour
{

    public GameObject visual,head;
    public GameObject Grip;


    Vector3 StartPosition,ProgressPosition, EndPosition;
    Vector3 mOffset;
    float mZCoord;
    private bool tempLock = false;
    private EventController _evenController;
    private void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        _evenController = EventController.Instance;
        _evenController.BallIsHit += OnBallHit;
    }

    private void OnDisable()
    {
        _evenController.BallIsHit -= OnBallHit;

    }
    private void OnBallHit()
    {
        StopCoroutine("removeLockInSecond");
        tempLock = true;
        StartCoroutine("removeLockInSecond");
    }

    private IEnumerator removeLockInSecond()
    {
        yield return new WaitForSeconds(0.5f);
        tempLock = false;
    }

    private void Update()
    {
        if (tempLock == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                mOffset = Grip.transform.position - GetMouseWorldPos();
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 targetPos = GetMouseWorldPos() + mOffset;
                targetPos.y = Grip.transform.position.y;
                Grip.transform.position = Vector3.Lerp(Grip.transform.position, targetPos, 11f);

            }


        }
        if (Input.GetMouseButtonUp(0))
        {
            tempLock = false;
        }

        GameManager.Instance.ball.transform.LookAt(this.transform);

    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = mZCoord * 3f;
        return Camera.main.ScreenToWorldPoint(mousPos);
    }

}
