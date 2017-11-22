using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour {

    private Enemy[] enemies;

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

    // Use this for initialization
    void Start () {

        // get total enemies
        enemies = GetComponentsInChildren<Enemy>();
        enemyCount = enemies.Length;

        Debug.Log("Total Enemies: " + enemyCount);

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

        Debug.Log("Current Enemies: " + currentEnemyCount);
    }



}
