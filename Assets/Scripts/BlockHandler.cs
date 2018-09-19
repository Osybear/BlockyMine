using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour {

	public GameObject blockPrefab;
	public GameObject ghostHolder;

	public void onMouseDown(GameObject block) {
		bool top = getBlock(block, block.transform.up);
		bool bottom = getBlock(block, -block.transform.up);
		bool right = getBlock(block, block.transform.right);
		bool left = getBlock(block, -block.transform.right);
		bool forward = getBlock(block, block.transform.forward);
		bool backward = getBlock(block, -block.transform.forward);

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

	public void InstantiateBlock(GameObject block, Vector3 direction){
		GameObject clone = Instantiate(blockPrefab, block.transform.position + direction * block.transform.lossyScale.x, Quaternion.identity, transform);
		clone.name = blockPrefab.name;
	}

	public bool getBlock(GameObject block, Vector3 direction){
		Ray ray = new Ray(block.transform.position, direction);
		RaycastHit hitInfo;
		
        if (Physics.Raycast(ray, out hitInfo, block.transform.lossyScale.x)){
			Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 2f);
			if(hitInfo.transform.name.Equals("Block"))
				return true;
			else if(hitInfo.transform.name.Contains("Ghost"))
				return true;
		}
		return false;
	}
}
