using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameManager gameManager;
    private Camera camera;
    public CAMERA_OPTION currentCameraOption = CAMERA_OPTION.BIRD_VIEW;

    public float minDistanceToFocus;
    public float maxDistanceToFocus;
    public float minDistance;
    public float maxDistance;
    public float minZoom;
    public float maxZoom;

    

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCameraOption == CAMERA_OPTION.BIRD_VIEW)
        {
            if (gameManager.distanceToHole >= minDistance && gameManager.distanceToHole <= maxDistance)
            {
                this.UpdateZoom(gameManager.distanceToHole);
            }
            else if (gameManager.distanceToHole > maxDistance)
            {
                Camera.main.fieldOfView = minZoom;
            }

            if (gameManager.distanceToHole >= minDistanceToFocus && gameManager.distanceToHole <= maxDistanceToFocus)
            {
                this.UpdateFocus(gameManager.distanceToHole);
            }
            else if (gameManager.distanceToHole > maxDistanceToFocus)
            {
                gameManager.focusPriority = 0;
            };
        }
        else if (currentCameraOption == CAMERA_OPTION.FIRST_PERSON)
        {

        }

    }

    public void UpdateZoom(float distance)
    {
        float diffA = maxDistance - minDistance;
        float diffB = maxZoom - minZoom;
        float step = diffA / diffB;

        Camera.main.fieldOfView = distance * step + minZoom;
    }
    public void UpdateFocus(float distance)
    {
        float diffA = maxDistanceToFocus - minDistanceToFocus;
        float diffB = 1;
        float step = diffB / diffA;
 

        gameManager.focusPriority = 1 - (distance * step);

    }
}


public enum CAMERA_OPTION
{
    BIRD_VIEW,
    FIRST_PERSON
}