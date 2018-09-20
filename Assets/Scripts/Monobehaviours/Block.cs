using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public BlockData blockData;
	public int depth;

	public void setBlock(){
		GetComponent<Renderer>().material = blockData.material;
		name = blockData.name;
	}
}
