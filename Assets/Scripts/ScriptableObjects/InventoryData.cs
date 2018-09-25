using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu]
public class InventoryData : ScriptableObject {

	public BlockData tempBlockData;
	public UnityEvent onIncrementCount;
	public List<BlockCount> blockCountList;

	public void IncrementCount(BlockData blockData, int amount){
		BlockCount blockCount = GetBlockCount(blockData);
		if(blockCount != null)
			blockCount.count += amount;
		else
			blockCountList.Add(new BlockCount(blockData));

		//event stuff
		tempBlockData = blockData;
		onIncrementCount.Invoke();
	}

	public BlockCount GetBlockCount(BlockData blockData){
		int index = blockCountList.IndexOf(new BlockCount(blockData));
		if(index == -1)
			return null;
		else
			return blockCountList[index]; 
	}	
}

[Serializable] 
public class BlockCount : IEquatable<BlockCount>{
	public BlockData blockData;
	public int count = 1;

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
