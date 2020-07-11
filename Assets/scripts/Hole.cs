using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public UnityEvent onPut;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        onPut.Invoke();
    }
    
        
    
}
