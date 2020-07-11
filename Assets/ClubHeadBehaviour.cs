using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubHeadBehaviour : MonoBehaviour
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
}
