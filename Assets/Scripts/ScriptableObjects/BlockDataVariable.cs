using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlockDataVariable : ScriptableObject {

	[TextArea]
	public string developerDescription;
	public BlockData value;
}
