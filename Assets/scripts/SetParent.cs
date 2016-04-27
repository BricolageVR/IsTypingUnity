using UnityEngine;
using System.Collections;

public class SetParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [SerializeField]
    private Transform newParent;
    void setParent()
    {
        transform.parent = newParent;
    }
}
