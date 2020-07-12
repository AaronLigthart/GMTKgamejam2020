﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubBehaviour : MonoBehaviour
{

    public GameObject visual,head;
    public GameObject Grip;


    Vector3 StartPosition,ProgressPosition, EndPosition;
    Vector3 mOffset;
    float mZCoord;
    private EventController _evenController;
    private void Start()
    {

    }

    private void OnEnable()
    {
        _evenController.BallIsHit += OnBallHit;
    }

    private void OnDisable()
    {
        _evenController.BallIsHit -= OnBallHit;

    }
    private void OnBallHit()
    {

    }

    private void Update()
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
            Grip.transform.position = targetPos;

        }

    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousPos);
    }

}
