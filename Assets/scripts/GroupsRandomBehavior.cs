using UnityEngine;
using System.Collections;
using System;

public class GroupsRandomBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }

    [SerializeField]
    private Vector3 radius;
    
    // Update is called once per frame
    void Update () {
       SineMove();
	}

    

    private void SineMove()
    {
        transform.localPosition = new Vector3(Mathf.Sin(Time.time) * radius.x,
                                              Mathf.Sin(Time.time)* radius.y, 
                                              Mathf.Sin(Time.time) * radius.z);
    }

}
