﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour {

	public GameObject blockPrefab;
	public GameObject ghostHolder;
	public Transform map;
	public List<LayerData> layerList;

	private void Awake() {
		//set the init blocks that are already in the world map
		foreach(Transform block in map){
			setBlock(block.GetComponent<Block>());
		}
	}

	public void onMouseDown(Block block) {
		bool top = getBlock(block.transform, block.transform.up);
		bool bottom = getBlock(block.transform, -block.transform.up);
		bool right = getBlock(block.transform, block.transform.right);
		bool left = getBlock(block.transform, -block.transform.right);
		bool forward = getBlock(block.transform, block.transform.forward);
		bool backward = getBlock(block.transform, -block.transform.forward);

		if(!top)
			InstantiateBlock(block, block.transform.up);
		if(!bottom)
			InstantiateBlock(block, -block.transform.up);
		if(!right)
			InstantiateBlock(block, block.transform.right);
		if(!left)
			InstantiateBlock(block, -block.transform.right);
		if(!forward)
			InstantiateBlock(block, block.transform.forward);
		if(!backward)
			InstantiateBlock(block, -block.transform.forward);
		
		BoxCollider collider = ghostHolder.AddComponent(typeof(BoxCollider)) as BoxCollider;
		collider.center = block.transform.position;
		collider.size = block.transform.lossyScale;
		
		Destroy(block.gameObject);
	}	

	public void InstantiateBlock(Block block, Vector3 direction){
		GameObject clone = Instantiate(blockPrefab, block.transform.position + direction * block.transform.lossyScale.x, Quaternion.identity, transform);
		Block cloneBlock = clone.GetComponent<Block>();
		cloneBlock.depth += block.depth + (int)-direction.y;
		setBlock(clone.GetComponent<Block>());
		clone.name = blockPrefab.name;
		
	}

	public bool getBlock(Transform block, Vector3 direction){
		Ray ray = new Ray(block.position, direction);
		RaycastHit hitInfo;
		
        if (Physics.Raycast(ray, out hitInfo, block.lossyScale.x)){
			Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 2f);
			if(hitInfo.transform.name.Equals("Block"))
				return true;
			else if(hitInfo.transform.name.Contains("Ghost"))
				return true;
			else if(hitInfo.transform.name.Equals("Player"))
				return true;
		}
		return false;
	}

	public void setBlock(Block block){
		int depth = block.depth; 
		foreach(LayerData layer in layerList){
			if(layer.depthCheck(depth))
				block.blockData = layer.GetBlockData();
		}
	}

}