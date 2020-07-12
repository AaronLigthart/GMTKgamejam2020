using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubHeadBehaviour : MonoBehaviour
{
    public Rigidbody t;
    public LineRenderer line;
    public List<Vector3> VelocityPower = new List<Vector3>();

    private void Start()
    {
        StartCoroutine(CheckVelocityPower());
    }

     private IEnumerator CheckVelocityPower()
    {
        while (true)
        {
            VelocityPower.Add(t.velocity);
            if (VelocityPower.Count > 5)
            {
                VelocityPower.RemoveAt(0);
            }
            yield return new WaitForSeconds(0.2f);

        }
        yield return new WaitForEndOfFrame();
    }
    private void OnTriggerEnter(Collider collision)
    {
        Rigidbody t = collision.gameObject.GetComponent<Rigidbody>();
        if (t != null)
        {
            Vector3 x = ((t.velocity) + CheckReceivedDirection(t.transform.position) * (10*Vector3.Distance(VelocityPower[0], VelocityPower[VelocityPower.Count - 1])));
            VelocityPower.Clear();
            x.y = 0;
            line.SetPosition(0, t.transform.position);
            line.SetPosition(1, t.transform.position + (x));
            t.AddForce(x * 100);
            Debug.Log(t.gameObject.name + " -- " + x + "WORK");
        }


    }

    private Vector3 CheckReceivedDirection(Vector3 targetPosition)
    {
        Vector3 diff = targetPosition - transform.position;
        return diff;
    }
}
