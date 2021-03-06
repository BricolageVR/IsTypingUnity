﻿using UnityEngine;
using System.Collections;

public class Image1Control : MonoBehaviour {
    [System.Serializable]
    public struct action
    {
        public Transform obj;
        public float delay;
    }
	// Use this for initialization
	void Start () {
	
	}
    public action[] actions;
    public Transform cam;
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            cam.rotation = Quaternion.identity;
            Debug.Log("Presentation started");
            for(int i = 0;i<actions.Length;i++)
            {
                StartCoroutine(startAction(actions[i]));
            }
        }
	
	}

    IEnumerator startAction(action act)
    {
        yield return new WaitForSeconds(act.delay);
        act.obj.GetComponent<IEnable>().Enable(null);
    }
}
