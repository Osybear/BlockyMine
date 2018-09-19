using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public BlockHandler blockHandler;
	public LayerMask layerMask;
	public Camera mainCamera;
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
        	if (Physics.Raycast(ray, out hitInfo, float.MaxValue, layerMask))
			{
				if(hitInfo.transform.name.Equals("Block")){
					blockHandler.onMouseDown(hitInfo.transform.gameObject);
				}
			}
		}
	}
}
