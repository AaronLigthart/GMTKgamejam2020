using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    public int currentLevelIndex;
    public GameObject currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        this.currentLevel = levels[currentLevelIndex];
        this.SpawnLevel(this.currentLevel);
    }

    // Update is called once per frame
    public void gotoNextLevel()
    {
        GameObject nextLevel = levels[this.currentLevelIndex];
        this.currentLevel.SetActive(false);
        SpawnLevel(nextLevel);
        GameObject.Destroy(this.currentLevel);
        this.currentLevel = nextLevel;
    }

    public void SpawnLevel(GameObject level)
    {
        Instantiate(level, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
