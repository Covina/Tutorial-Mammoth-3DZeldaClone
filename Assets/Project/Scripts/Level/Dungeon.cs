using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour {

    private int enemyCount;
    private int currentEnemyCount;

	// Use this for initialization
	void Start () {

        // get total enemies
        enemyCount = GetComponentsInChildren<Enemy>().Length;
        Debug.Log("Total Enemies: " + enemyCount);

	}
	
	// Update is called once per frame
	void Update () {

        // get total enemies
        currentEnemyCount = GetComponentsInChildren<Enemy>().Length;

        Debug.Log("Current Enemies: " + currentEnemyCount);
    }



}
