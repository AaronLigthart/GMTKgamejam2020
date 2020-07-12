using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScale : MonoBehaviour
{
    public Vector3 newScale;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = newScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
