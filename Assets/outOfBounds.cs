using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class outOfBounds : MonoBehaviour
{
    public UnityEvent outOfBoundsEvent;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            other.GetComponent<Ball>().Reset();

        }
    }
}
