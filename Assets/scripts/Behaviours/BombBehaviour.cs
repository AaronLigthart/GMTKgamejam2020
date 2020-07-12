using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public int segments = 50;
    public float xradius = 5;
    public float yradius = 5;
    public float angle = 20;
    public LineRenderer line;
    public BallExplosionBehaviour head;
    void Start()
    {
        //line = gameObject.GetComponent<LineRenderer>();
        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z;

        angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, 0, y));

            angle += (360f / segments);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Timer());
    }
    private void OnDisable()
    {
        head.usedBombs.Remove(this);
        head.availableBombs.Add(this);
        head.ReceiveExplosionAt(transform.position);
        head.ShowExplosion(transform.position);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }


}
