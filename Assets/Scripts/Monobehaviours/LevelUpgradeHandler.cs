using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpgradeHandler : MonoBehaviour {

	public PlayerData player;
	public GameObject holder;

	private void Start() {
		holder.SetActive(false);	
	}

	public void UpgradeStrength(){
		//increase strength by 10% by adding 
		player.UpdateStrength(player.strength * .1f);
	}

	public void UpgradeFireRate(){
		//decrese the firerate by 10% increasing speed by 10%???
		player.UpdateFireRate(-player.fireRate * .1f);
	}
}
