using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class ShopHandler : MonoBehaviour {

	public InventoryData inventory;
	public PlayerData player;
	public GameObject holder;
	public GameObject buyHolder;
	public GameObject sellHolder;
	public InputField nameField;
	public InputField amountField;
	public List<BlockData> blockDataList; // list of blocks the player can sell
	public GameEvent onEnablePlayer;
	public GameEvent onDisablePlayer;

	private void Start() {
		holder.SetActive(false);	
		sellHolder.SetActive(false);
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.I) && !nameField.isFocused && !amountField.isFocused){
			if(holder.activeInHierarchy){
				holder.SetActive(false);
				onEnablePlayer.Raise();
			}else{
				holder.SetActive(true);
				onDisablePlayer.Raise();
			}
		}	
	}

	public void SellBlock(){
		BlockData blockData = GetBlockData(nameField.text);
		if(blockData == null){
			nameField.text = "Unknown";
		}else{
			BlockCount blockCount = inventory.GetBlockCount(blockData);
			int amount = int.Parse(amountField.text);
			if(blockCount != null){
				if(blockCount.count < amount){
					inventory.UpdateMoney(blockCount.count * blockData.moneyValue);
					inventory.UpdateBlockCount(blockData, -blockCount.count);
				}else{
					inventory.UpdateMoney(amount * blockData.moneyValue);
					inventory.UpdateBlockCount(blockData, -amount);
				}
			}
			amountField.text = null;
			nameField.text = null;
		}
	}

	public BlockData GetBlockData(string name){
		foreach(BlockData blockData in blockDataList){
			if(blockData.name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
				return blockData;
		}
		return null;
	}

	//decrease firerate by 5% for $50
	public void BuySpeed(){
		if(inventory.money >= 50){
			inventory.UpdateMoney(-50);
			player.UpdateFireRate(-player.fireRate * .05f);
		}
	}

	//increase strength by 5% for $50
	public void BuyStrength(){
		if(inventory.money >= 50){
			inventory.UpdateMoney(-50);
			player.UpdateStrength(player.strength * .05f);
		}
	}
}
