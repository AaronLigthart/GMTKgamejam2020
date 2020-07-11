using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }
}
