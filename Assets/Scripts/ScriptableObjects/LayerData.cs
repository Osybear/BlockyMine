using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LayerData : ScriptableObject {

	public BlockData layerBlock;
	public int min, max; 
	public List<SpawnableBlocks> spawnable;

	public BlockData GetBlockData(){
		foreach(SpawnableBlocks block in spawnable){
			float randomNum = Random.Range(0, 100f);
			if(randomNum <= block.spawnChance)
				return block.blockData;
		}
		return layerBlock;
	}

	public bool DepthCheck(int depth){
		if(depth >= min && depth <= max)
			return true;
		return false;
	}
}

[System.Serializable]
public class SpawnableBlocks{
	public BlockData blockData;
	[Range(0,100f)]
	public float spawnChance;

}
