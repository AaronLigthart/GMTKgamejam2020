using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    public int currentLevelIndex;
    public GameObject currentLevel;
    public GameObject currentSpawnedLevel;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        this.currentLevel = levels[currentLevelIndex];
    }

    // Update is called once per frame
    public void gotoNextLevel()
    {
        this.currentLevelIndex += 1;
        print("count "+levels.Count);
        if(this.currentLevelIndex > levels.Count-1)
        {
            this.currentLevelIndex = 0;
        }
        print(this.currentLevelIndex);
        
        GameObject nextLevel = levels[this.currentLevelIndex];
        Destroy(currentSpawnedLevel);
        SpawnLevel(nextLevel);
        this.currentLevel = nextLevel;
        print("hello");
    }

    public void SpawnLevel(GameObject level)
    {
        currentSpawnedLevel = Instantiate(level, new Vector3(0, 0, 0), Quaternion.identity);
        this.SetProperties(level);

    }
    public void SetProperties(GameObject level)
    {
        Level levelProperties = level.GetComponent<Level>();
        gameManager.hole = levelProperties.hole;
        gameManager.spawnPositon = levelProperties.spawnPoint;
        print("AAA" + gameManager.cameraFocusPoint.GetComponent<LookAt>().target);
        gameManager.cameraFocusPoint.GetComponent<LookAt>().target = gameManager.hole.transform;
        gameManager.ResetBall();


    }
}
