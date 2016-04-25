using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Createetters : MonoBehaviour {

    public Transform tRef;
    public List<Transform> obj;
    public Vector3 pos;
	// Use this for initialization
	void Start () {
        obj = new List<Transform>();
        pos = transform.position;
	    for(int i = 0;i<5;i++)
        {
            GameObject p = new GameObject();
            p.transform.position = pos + i * Vector3.forward;
            for(int j = 0;j<20;j++)
            {
                Transform t = (Transform)(Instantiate(tRef, pos + Vector3.right * j + i * Vector3.forward, Quaternion.identity));
                t.GetComponent<Animator>().Play("C4D Animation Take");
                t.parent = p.transform;
            }
            obj.Add(p.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
