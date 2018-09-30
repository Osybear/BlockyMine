using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopHandler : MonoBehaviour {

	public InventoryData inventory;
	public GameObject holder;
	public InputField inputField;
	public UnityEvent onOpenShop;
	public UnityEvent onCloseShop;

	private void Start() {
		holder.SetActive(false);	
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.I)){
			if(holder.activeInHierarchy){
				holder.SetActive(false);
				onCloseShop.Invoke();
			}else{
				holder.SetActive(true);
				onOpenShop.Invoke();
			}
		}	
	}

	public void SellBlock(BlockData blockData){
		BlockCount blockCount = inventory.GetBlockCount(blockData);
		int amount = int.Parse(inputField.text);
		if(blockCount != null){
			if(blockCount.count < amount){
				inventory.ChangeMoney(blockCount.count * blockData.value);
				inventory.ChangeBlockCount(blockData, -blockCount.count);
				inputField.text = null;
			}else{
				inventory.ChangeMoney(amount * blockData.value);
				inventory.ChangeBlockCount(blockData, -amount);
				inputField.text = null;
			}
		}
	}

}
