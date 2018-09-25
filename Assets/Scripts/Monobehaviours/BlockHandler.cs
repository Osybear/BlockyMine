using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour {

	public InventoryData inventory;
	public GameObject blockPrefab;
	public GameObject ghostHolder;
	public Transform map;
	public List<LayerData> layerList;
	
	private void Awake() {
		//set the init blocks that are already in the world map
		foreach(Transform block in map){
			Block blockScript = block.GetComponent<Block>();
			blockScript.blockData = GetBlockData(blockScript.depth);
			blockScript.setBlock();
		}
	}

	public void onMouseDown(Block block) {
		bool top = BlockHit(block.transform, block.transform.up);
		bool bottom = BlockHit(block.transform, -block.transform.up);
		bool right = BlockHit(block.transform, block.transform.right);
		bool left = BlockHit(block.transform, -block.transform.right);
		bool forward = BlockHit(block.transform, block.transform.forward);
		bool backward = BlockHit(block.transform, -block.transform.forward);

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
		
		inventory.ChangeCount(block.blockData, 1);
		Destroy(block.gameObject);
	}	

	public void InstantiateBlock(Block block, Vector3 direction){
		GameObject clone = Instantiate(blockPrefab, block.transform.position + direction * block.transform.lossyScale.x, Quaternion.identity, transform);
		Block cloneBlock = clone.GetComponent<Block>();
		cloneBlock.depth += block.depth + (int)-direction.y;
		cloneBlock.blockData = GetBlockData(cloneBlock.depth);
		cloneBlock.setBlock();
	}

	public bool BlockHit(Transform block, Vector3 direction){
		Ray ray = new Ray(block.position, direction);
		RaycastHit hitInfo;
		
        if (Physics.Raycast(ray, out hitInfo, block.lossyScale.x)){
			Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 2f);
			if(hitInfo.transform.tag.Equals("Block") || hitInfo.transform.tag.Equals("Player"))
				return true;
		}
		return false;
	}

	public BlockData GetBlockData(int depth){
		foreach(LayerData layer in layerList){
			if(layer.DepthCheck(depth)){
				return layer.GetBlockData(); 
			}
		}
		return null;
	}

}
