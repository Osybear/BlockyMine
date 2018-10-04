using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevelData : MonoBehaviour {

	public PlayerData player;
	public Image expBarImage;
	public Text levelText;
	
	private void Start() {
		UpdateExpBar();
		UpdateLevelText();
	}

	public void UpdateExpBar(){
		expBarImage.fillAmount = player.currExp / player.expLeft;
	} 

	public void UpdateLevelText(){
		levelText.text = player.curLevel.ToString();
	}
}
