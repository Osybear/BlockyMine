using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LayerData : ScriptableObject {

	public BlockData layerBlock;
	public List<BlockList> blocks;
}

[System.Serializable]
public class BlockList{
	public BlockData blockData;
	[Range(0,100)]
	public float spawnChance;
}
