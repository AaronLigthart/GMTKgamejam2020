using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubHeadBehaviour : MonoBehaviour
{
    public Rigidbody t;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody t = collision.gameObject.GetComponent<Rigidbody>();
        if (t != null)
        {
            Vector3 x = (Vector3.Normalize(t.velocity) + CheckReceivedDirection(t.transform.position)) * 1000;
            x.y = 0;
            t.AddForce(x);
        }


    }

    private Vector3 CheckReceivedDirection(Vector3 targetPosition)
    {
        Vector3 diff = targetPosition - transform.position;
        return diff;
    }
}
