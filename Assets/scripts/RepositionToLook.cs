using UnityEngine;
using System.Collections;

public class RepositionToLook : MonoBehaviour {

    [SerializeField]
    private Transform reference;
    [SerializeField]
    private float offset = 1;
    [SerializeField]
    private Transform cam;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        cam.rotation = Quaternion.identity;
    }
}
