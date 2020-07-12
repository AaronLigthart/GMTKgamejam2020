using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubHeadBehaviour : MonoBehaviour
{
    public Rigidbody targetRigidbody;
    public LineRenderer line;
    public List<Vector3> VelocityPower = new List<Vector3>();
    private EventController _eventController;


    private void Start()
    {
        if (targetRigidbody == null)
        {
            targetRigidbody = GetComponent<Rigidbody>();
        }
        line = GameObject.Find("line").GetComponent<LineRenderer>();
        _eventController = EventController.Instance;
        StartCoroutine(CheckVelocityPower());
    }

     private IEnumerator CheckVelocityPower()
    {
        while (true)
        {
            VelocityPower.Add(targetRigidbody.velocity);
            if (VelocityPower.Count > 5)
            {
                VelocityPower.RemoveAt(0);
            }
            yield return new WaitForSeconds(0.2f);

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Rigidbody t = collision.gameObject.GetComponent<Rigidbody>();
        if (t != null)
        {
            Vector3 x = (CheckReceivedDirection(t.transform.position) * (15*Vector3.Distance(VelocityPower[0], VelocityPower[VelocityPower.Count - 1])));
            VelocityPower.Clear();
            t.angularDrag = 0;
            t.angularVelocity = Vector3.zero;
            x.y = 0;
            Debug.Log("<color=blue> x = " + t.velocity + "</color>");
            t.AddForce(x + t.velocity, ForceMode.Impulse);
            if (line != null)
            {
                line.SetPosition(0, t.transform.position);
                line.SetPosition(1, t.transform.position + (x));

            }
            if (t.name == "Ball")
            {
                _eventController.BallIsHitCall();
            }
        }


    }

    private Vector3 CheckReceivedDirection(Vector3 targetPosition)
    {
        Vector3 diff = targetPosition - transform.position;
        return diff;
    }
}
