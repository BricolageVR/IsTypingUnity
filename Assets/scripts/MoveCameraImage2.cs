using UnityEngine;
using System.Collections;

public class MoveCameraImage2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [SerializeField]
    private Transform cam;
    void StartCameraMovement(string booleanName)
    {
        cam.GetComponent<Animator>().SetBool(booleanName, true);
    }
}
