using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanchincoBallBehaviour : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pin")
        {
            _audioManager.OnPinHit(collision.gameObject.transform.position);
        }
    }

}
