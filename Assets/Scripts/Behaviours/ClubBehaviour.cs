using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubBehaviour : MonoBehaviour
{

    public CLUBPROGRESS ownProgress = CLUBPROGRESS.DETERMINE_POSITION;
    public GameObject ball, visual;
    public GameObject Grip;

    public enum CLUBPROGRESS
    {
        DETERMINE_POSITION,
        DETERMINE_POWER,
        HIT,
    }

    Vector3 StartPosition,ProgressPosition, EndPosition;
    private void Update()
    {
        if (ownProgress == CLUBPROGRESS.DETERMINE_POSITION)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit,20)){
                if (hit.transform.name == "Plane")
                {
                    Vector3 targetPosition= new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    Grip.transform.position = Vector3.Lerp(transform.position,targetPosition,0.5f);
                    visual.transform.LookAt(ball.transform.position);
                }
            }

            //transform.position = new Vector3(MousePos.x, transform.position.y, MousePos.y);
            if (Input.GetMouseButtonDown(0))
            {
                StartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                //ownProgress = CLUBPROGRESS.DETERMINE_POWER;
            }
        }
        else if(ownProgress == CLUBPROGRESS.DETERMINE_POWER)
        {
            if (Input.GetMouseButton(0))
            {
                ProgressPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                float DifferenceX = ((StartPosition.x - ProgressPosition.x));
                transform.RotateAround(this.transform.position, new Vector3(DifferenceX, 0, 0),1);
            }
            if (Input.GetMouseButtonUp(0))
            {
                StartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }

        }
    }

}
