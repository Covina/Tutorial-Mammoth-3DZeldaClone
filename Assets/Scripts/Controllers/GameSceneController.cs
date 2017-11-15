using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour {

    [Header("Game")]
    public Player player;

    [Header("UI")]
    public Text healthText;
    public Text bombText;
    public Text arrowText;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(player != null)
        {
            healthText.text = "Health: " + player.health;
            bombText.text = "Bombs: " + player.BombAmount;
            arrowText.text = "Arrows: " + player.arrowAmount;

        } else
        {
            healthText.text = "Health: 0";
        }
        

	}
}
