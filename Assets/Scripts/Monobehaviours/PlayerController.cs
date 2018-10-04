using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public PlayerData playerData;
	public LayerMask layerMask;
	public Camera mainCamera;

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
			RaycastHit hitInfo;

        	if (Physics.Raycast(ray, out hitInfo, playerData.interactDistance, layerMask))
			{
				Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 3f);
				if(hitInfo.transform.tag.Equals("Block")){
					Block block = hitInfo.transform.gameObject.GetComponent<Block>();
					block.DamageBlock(playerData.strength);
				}
			}
		}
	}
}
