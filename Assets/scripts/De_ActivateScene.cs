using UnityEngine;
using System.Collections;

public class De_ActivateScene : MonoBehaviour {

    public GameObject sceneActivate;
    public GameObject sceneDeActivate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        if(sceneActivate != null)
            sceneActivate.SetActive(true);
        if(sceneDeActivate != null)
            sceneDeActivate.SetActive(false);
    }
}
