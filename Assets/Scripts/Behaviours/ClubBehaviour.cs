using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody t = collision.gameObject.GetComponent<Rigidbody>();
        if (t != null)
        {
            Debug.Log("Work");
            t.AddRelativeForce(Vector3.forward * 1050);
        }


    }

    Vector3 StartPosition,ProgressPosition, EndPosition;
    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            StartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log("pos = " + StartPosition);
        }
        if (Input.GetMouseButton(0))
        {
            ProgressPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float DifferenceX = ((StartPosition.x - ProgressPosition.x) * 5);
            transform.Rotate(transform.rotation.x + DifferenceX, transform.rotation.y , transform.rotation.z);
            Debug.Log("pos = " + ProgressPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log("pos = " + StartPosition);
        }
    }
}
