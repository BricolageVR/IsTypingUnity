using UnityEngine;
using System.Collections;

public class ActivateImage4 : MonoBehaviour {

    [SerializeField]
    private Material skyboxNight;
	// Use this for initialization
	void Start () {
        RenderSettings.skybox = skyboxNight;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
