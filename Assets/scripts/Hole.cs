using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Hole : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Ball")
        {
            other.GetComponent<Ball>().gameManager.levelManager.gotoNextLevel();
        }
    }
    
        
    
}
