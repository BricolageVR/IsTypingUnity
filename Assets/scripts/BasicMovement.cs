using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        self = transform;
        yAxis = self.position.y;
	}
    public float radius = 1;
    Transform self;
    float yAxis = 0;
	// Update is called once per frame
	void Update () {
        self.position = new Vector3(radius * Mathf.Sin(Time.time),yAxis, radius * Mathf.Cos(Time.time));
	}
}
