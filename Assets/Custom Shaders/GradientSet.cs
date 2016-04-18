using UnityEngine;
using System.Collections;

public class GradientSet : MonoBehaviour {

    public Color startColor;
    public Color endColor;

	// Use this for initialization
	void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Color[] colors = new Color[mesh.vertices.Length];
        colors[0] = startColor;
        colors[1] = endColor;
        colors[2] = startColor;
        colors[3] = endColor;
        mesh.colors = colors;	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
