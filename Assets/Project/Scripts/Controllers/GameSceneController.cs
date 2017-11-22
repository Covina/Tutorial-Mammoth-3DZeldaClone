using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour {

    [Header("Game")]
    public Player player;

    [Header("UI")]
    public GameObject[] hearts;

    public Text healthText;
    public Text bombText;
    public Text arrowText;

    public GameObject dungeonPanel;
    public Text dungeonInfoText;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(player != null)
        {
            // Set the heart health display
            for(int i = 0; i < hearts.Length; i++)
            {
                // ternary operator to determine whether to enable or disable the heart
                hearts[i].SetActive(i < player.health);

            }


            healthText.text = "Health: " + player.health;
            bombText.text = "Bombs: " + player.BombAmount;
            arrowText.text = "Arrows: " + player.arrowAmount;

            // Check for dungeon information
            Dungeon currentDungeon = player.CurrentDungeon;
            dungeonPanel.SetActive(currentDungeon != null);

            if(currentDungeon != null)
            {
                // cast one to float to force result to return float
                float clearPercentage = (float)(currentDungeon.EnemyCount - currentDungeon.CurrentEnemyCount) / currentDungeon.EnemyCount;

                //Debug.Log(currentDungeon.EnemyCount + "," + currentDungeon.CurrentEnemyCount + "," + clearPercentage);
                dungeonInfoText.text = "Progress: " + Mathf.FloorToInt(clearPercentage * 100) + " %";
            }

        } else
        {
            // Disable all hearts (hero is dead)
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].SetActive(false);
            }
        }
        

	}
}
