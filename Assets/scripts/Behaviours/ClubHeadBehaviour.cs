using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubHeadBehaviour : MonoBehaviour
{
    public Rigidbody t;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody t = collision.gameObject.GetComponent<Rigidbody>();
        Debug.Log("Work?");
        if (t != null)
        {
            Debug.Log("Work = " + Vector3.Normalize(t.velocity) + " - " +CheckReceivedDirection(t.transform.position));
            Vector3 x = (Vector3.Normalize(t.velocity) + CheckReceivedDirection(t.transform.position)) * 1000;
            x.y = 0;
            t.AddForce(x);//CheckReceivedDirection(collision.transform.position) * 1050);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody t = other.gameObject.GetComponent<Rigidbody>();
        Debug.Log("blues?");
        if (t != null)
        {
            Debug.Log("blues");
            t.AddRelativeForce(Vector3.forward * 1050);
        }
    }

    private Vector3 CheckReceivedDirection(Vector3 targetPosition)
    {
        Vector3 diff = targetPosition - transform.position;
        return diff;
    }
}
