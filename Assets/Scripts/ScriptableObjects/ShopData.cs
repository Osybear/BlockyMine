using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ShopData : ScriptableObject {

	public InventoryData inventory;
	public float playerMoney;
	public BlockData testBlockData;
	public UnityEvent onValueChanged;
							//block to sell       //amount they awnt to sell
	public void SellBlock(BlockData blockData, int amount){
		BlockCount blockCount = inventory.GetBlockCount(blockData);
		if(blockCount != null){
			if(blockCount.count < amount){
				playerMoney += blockCount.count * blockData.value;
				onValueChanged.Invoke();
				inventory.ChangeCount(blockData, -blockCount.count);
			}else{
				playerMoney += amount * blockData.value;
				onValueChanged.Invoke();
				inventory.ChangeCount(blockData, -amount);
			}
		}
	}

	public void SellStuff(){
		SellBlock(testBlockData, 100);
	}
}
