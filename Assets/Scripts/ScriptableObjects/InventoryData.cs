using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu]
public class InventoryData : ScriptableObject {

	public float money = 0;
	public BlockData tempBlockData; // when ChangeCount() is called variable is set with data that was changed.
	public UnityEvent onChangeBlockCount;
	public UnityEvent onChangeMoney;
	public List<BlockCount> blockCountList;

	public void ChangeBlockCount(BlockData blockData, int amount){
		BlockCount blockCount = GetBlockCount(blockData);
		if(blockCount != null){
			blockCount.count += amount;
			if(blockCount.count == 0)
				blockCountList.Remove(blockCount);
		}
		else
			blockCountList.Add(new BlockCount(blockData));
			
		//data setter and event raising below
		tempBlockData = blockData;
		onChangeBlockCount.Invoke();
	}

	public void ChangeMoney(float amount){
		money += amount;
		onChangeMoney.Invoke();
	}

	public BlockCount GetBlockCount(BlockData blockData){
		int index = blockCountList.IndexOf(new BlockCount(blockData));
		if(index != -1)
			return blockCountList[index]; 
		else
			return null;
	}

	private void OnEnable() {
		blockCountList = new List<BlockCount>();
	}	
}

[Serializable] 
public class BlockCount : IEquatable<BlockCount>{
	public BlockData blockData;
	public int count = 1;

	public BlockCount(BlockData blockData, int count){
		this.blockData = blockData;
		this.count = count;
	}

	public BlockCount(BlockData blockData){
		this.blockData = blockData;
	}

    public bool Equals(BlockCount other)
    {
        if(other.blockData == blockData)
			return true;
		return false;
    }
}
