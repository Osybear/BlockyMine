﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class PlayerData : ScriptableObject {

	public float interactDistance;
	public int strength;
	public UnityEvent onUpdateExp;
    public UnityEvent onLevelUp;

    //http://wiki.unity3d.com/index.php/LevelUp
	//current level
    public int curLevel;
    //current exp amount
    public float currExp;
    //exp amount needed for lvl 1
    public int expBase;
    //exp amount left to next levelup
    public float expLeft;
    //modifier that increases needed exp each level
    public float expMod;
	
    private void OnEnable() {
        curLevel = 0;
        currExp = 0;
        expLeft = expBase;
        interactDistance = 25;  
        strength = 1;
    }

    public void GainExp(int amount)
    {
        currExp += amount;
        if(currExp >= expLeft)
            LevelUp();
		onUpdateExp.Invoke();
    }

    void LevelUp()
    {
        currExp -= expLeft;
        curLevel++;
		expLeft = expLeft + (expLeft * expMod);
        onLevelUp.Invoke();
    }
}
