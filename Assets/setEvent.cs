using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setEvent : MonoBehaviour
{
    public EventBox parent;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        parent.SetEvent();
    }
}
