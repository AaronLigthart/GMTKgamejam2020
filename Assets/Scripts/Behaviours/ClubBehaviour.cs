using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubBehaviour : MonoBehaviour
{

    public CLUBPROGRESS ownProgress = CLUBPROGRESS.DETERMINE_POSITION;
    public GameObject ball, visual,head;
    public GameObject Grip;

    public enum CLUBPROGRESS
    {
        DETERMINE_POSITION,
        DETERMINE_POWER,
        HIT,
    }

    Vector3 StartPosition,ProgressPosition, EndPosition;
    Vector3 mOffset;
    float mZCoord;
    private void Start()
    {
        Cursor.visible = false;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = Grip.transform.position - GetMouseWorldPos();
        StartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    private void Update()
    {
        if (ownProgress == CLUBPROGRESS.DETERMINE_POSITION)
        {
            Vector3 targetPos = GetMouseWorldPos() + mOffset;
            targetPos.y = Grip.transform.position.y;
            Grip.transform.position = targetPos;

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

    private void OnMouseDown()
    {
        
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousPos);
    }

}
