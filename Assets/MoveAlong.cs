using UnityEngine;
using System.Collections;

public class MoveAlong : MonoBehaviour {

	// Use this for initialization
	void Start () {
        self = this.transform;
    }
    public Transform target;
    public Transform self;
    public float speed = 1f;
	// Update is called once per frame
	void Update () {
        target = GetComponent<UnityStandardAssets.Utility.WaypointProgressTracker>().target;
        if(target!=null)
        {
            self.position = Vector3.Lerp(self.position, target.position, Time.deltaTime * speed);
        }
    }
}
