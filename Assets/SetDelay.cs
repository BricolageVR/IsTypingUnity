using UnityEngine;
using System.Collections;

public class SetDelay : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        script.enabled = false;
        StartCoroutine("startScripts");
	}
    public MonoBehaviour script;
    public float delaySeconds;
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator startScripts()
    {
        yield return new WaitForSeconds(delaySeconds);
        script.enabled = true;
    }
}
