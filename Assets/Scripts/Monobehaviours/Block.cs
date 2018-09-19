using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public BlockData blockData;
	public int depth;

	private void Start() {
		GetComponent<Renderer>().material = blockData.material;
	}
}
