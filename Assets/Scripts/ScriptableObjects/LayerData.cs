﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LayerData : ScriptableObject {

	public BlockData layerBlock;
	public List<BlockList> blocks;

	public BlockData GetBlockData(){
		foreach(BlockList block in blocks){
			float randomNum = Random.Range(0, 100f);
			if(randomNum <= block.spawnChance)
				return block.blockData;
		}

		return layerBlock;
	}
}

[System.Serializable]
public class BlockList{
	public BlockData blockData;
	[Range(0,100)]
	public float spawnChance;
}
