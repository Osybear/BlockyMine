using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpgradeHandler : MonoBehaviour {

	public PlayerData player;
	public GameObject holder;
	public UnityEvent onUpgradeSelected;

	private void Start() {
		holder.SetActive(false);	
	}

	public void StrengthUpgrade(){
		//increase strength by 10%
		float newStrength = player.strength + (player.strength * .1f); 
		player.UpdateStrength(newStrength);
		onUpgradeSelected.Invoke();
	}

	public void IncreaseDistance(){
		//increase interact distance by 50%;
		float newID = player.interactDistance + (player.interactDistance * .5f);
		player.UpdateID(newID);
		onUpgradeSelected.Invoke();
	}
}
