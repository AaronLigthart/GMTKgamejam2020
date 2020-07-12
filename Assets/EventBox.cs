using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBox : MonoBehaviour
{
    public GameManager gameManager;
    public enum Event { flipScreen, smallBall, bigball, air, ballShape, randomHoles, COUNT };
    public List<Sprite> eventSprites;
    public SpriteRenderer icon;
    // Start is called before the first frame update
    public Event eventOnHit;

    void Start()
    {
        int randomNumber = (int)Random.Range(0, (float)Event.COUNT);
        eventOnHit = (Event)Random.Range(randomNumber, randomNumber);
        icon.sprite = eventSprites[randomNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEvent()
    {
        gameManager.DoEvent(eventOnHit.ToString());
    }
}
