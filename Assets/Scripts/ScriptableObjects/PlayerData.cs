using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class PlayerData : ScriptableObject {

    public float fireRate;
	public float interactDistance;
	public float strength;

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
	
    public UnityEvent onUpdateExp;
    public UnityEvent onLevelUp;
    
    private void OnEnable() {
        curLevel = 0;
        currExp = 0;
        expLeft = expBase;
        interactDistance = float.MaxValue;  
        strength = 1;
    }

    public void UpdateID(float amount){
        interactDistance += amount;
    }

    public void UpdateStrength(float amount){
        strength += amount;
    }

    public void UpdateExp(float amount)
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
