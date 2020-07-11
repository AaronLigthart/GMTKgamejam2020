using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotOnGround : MonoBehaviour
{

    public Transform clubArea;
    void Update()
    {
        Vector3 x = clubArea.position;
        x.y = transform.position.y;
        transform.position = x;
    }
}
