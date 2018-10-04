using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpgradeHandler : MonoBehaviour {

	public PlayerData player;

	public void StrengthUpgrade(){
		//increase strength by 10%
		float newStrength = player.strength + (player.strength * .1f); 
		player.UpdateStrength(newStrength);
	}

	public void IncreaseDistance(){
		//increase interact distance by 50%;
		float newID = player.interactDistance + (player.interactDistance * .5f);
		player.UpdateID(newID);
	}
}
