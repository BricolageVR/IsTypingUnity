using UnityEngine;
using System.Collections;

public class GetMeshSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GetComponent<MeshFilter>().mesh.bounds.size);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
