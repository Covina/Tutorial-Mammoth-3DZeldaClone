﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // override the function from Enemy
    public override void Hit()
    {
        base.Hit();
    }

}
