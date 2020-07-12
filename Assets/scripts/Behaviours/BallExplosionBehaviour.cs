using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExplosionBehaviour : MonoBehaviour
{

    public List<BombBehaviour> availableBombs = new List<BombBehaviour>();
    public List<BombBehaviour> usedBombs = new List<BombBehaviour>();
    public LineRenderer line;
    public GameObject ball;
    public GameObject hole;
    private GameManager _gameManager;
    public float explosionPower = 500;
    public float explosionRadius = 20;
    private void Start()
    {
        _gameManager = GameManager.Instance;
        ball = _gameManager.ball;
        hole = _gameManager.hole;
        for (int i = 0; i < availableBombs.Count; i++)
        {
            availableBombs[i].head = this;
            availableBombs[i].angle = explosionRadius;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData, 1000))
            {
                if (hitData.transform.tag == "Floor")
                {
                    if (availableBombs.Count != 0)
                    {
                        Vector3 targetPosition = hitData.point;// new Vector3(hitData.point.x, transform.position.y, hitData.point.z);
                        BombBehaviour targetBomb =  availableBombs[0];
                        usedBombs.Add(targetBomb);
                        availableBombs.RemoveAt(0);
                        targetBomb.transform.position = targetPosition;
                        targetBomb.gameObject.SetActive(true);

                    }
                }

            }
        }
    }

    public void ReceiveExplosionAt(Vector3 posOfExplosion)
    {
        ball.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, posOfExplosion, explosionRadius);
    }
}
