using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour {


    private Enemy[] enemies;

    

    private bool isDungeonClear = false;

    private bool justCleared;
    public bool JustCleared
    {
        get {
            // can only be turned true once
            bool returnValue = justCleared;
            justCleared = false;
            return returnValue;
        }
    }


    private int enemyCount;
    public int EnemyCount
    {
        get { return enemyCount; }
    }

    private int currentEnemyCount = 0;
    public int CurrentEnemyCount
    {
        get { return currentEnemyCount; }
    }

    private Treasure treasure;
    public Treasure Treasure
    {
        get { return treasure; }
    }

    // Use this for initialization
    void Start () {

        // get total enemies
        enemies = GetComponentsInChildren<Enemy>();
        enemyCount = enemies.Length;

        //Debug.Log("Total Enemies: " + enemyCount);

        // Get reference to treasure and disable it
        treasure = GetComponentInChildren<Treasure>();
        treasure.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        currentEnemyCount = 0;
        foreach (Enemy enemy in enemies)
        {
            if(enemy != null)
            {
                currentEnemyCount++;
            }
        }

        // Debug.Log("Current Enemies: " + currentEnemyCount);

        // Check if the dungeon has been cleared
        if(isDungeonClear == false)
        {
            if(currentEnemyCount == 0)
            {
                justCleared = true;
                isDungeonClear = true;
                treasure.gameObject.SetActive(true);
                
            }
        }



    }



}
