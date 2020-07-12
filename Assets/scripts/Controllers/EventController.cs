using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : Singleton<EventController> {

    /*public event Action<int> CheckWinnerCardgame;
    void OnCheckWinnerCardgame(int criteria)
    {
        if (CheckWinnerCardgame != null)
        {
            CheckWinnerCardgame(criteria);
        }
    }
    public void CheckWinnerCardgameCall(int criteria)
    {
        OnCheckWinnerCardgame(criteria);
    }

    public event Action PlayersAssignedSeats;
    void OnPlayersAssignedSeats()
    {
        if (PlayersAssignedSeats != null)
        {
            PlayersAssignedSeats();
        }
    }
    public void PlayersAssignedSeatsCall()
    {
        OnPlayersAssignedSeats();
    }*/
    public event Action BallIsHit;
    void OnBallIsHit()
    {
        if (BallIsHit != null)
        {
            BallIsHit();
        }
    }
    public void BallIsHitCall()
    {
        OnBallIsHit();
    }

    public event Action<CAMERA_SHADER> ChangeCameraToShader;
    public void OnChangeCameraToShader(CAMERA_SHADER targetShader)
    {
        if (ChangeCameraToShader != null)
        {
            ChangeCameraToShader(targetShader);
        }
    }
    public void ChangeCameraToShaderCall(CAMERA_SHADER targetShader)
    {
        OnChangeCameraToShader(targetShader);
    }
}
