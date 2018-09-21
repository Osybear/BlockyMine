using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public BlockHandler blockHandler;
	public LayerMask layerMask;
	public Camera mainCamera;
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			//Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
			RaycastHit hitInfo;
        	if (Physics.Raycast(ray, out hitInfo, float.MaxValue, layerMask))
			{
				Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 3f);
				if(hitInfo.transform.tag.Equals("Block")){
					blockHandler.onMouseDown(hitInfo.transform.gameObject.GetComponent<Block>());
				}
			}
		}
	}
}
