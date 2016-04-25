using UnityEngine;
using System.Collections;

public class DisableSelf : MonoBehaviour,IEnable {

	// Use this for initialization
	void Start () {
	
	}
	public void Enable(object data)
    {
        gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
