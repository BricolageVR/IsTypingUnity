using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit info;
        if(Physics.Raycast(transform.position, transform.forward, out info))
        {
            Debug.Log(info.transform.parent.name);
            PopMessage m = info.transform.parent.GetComponent<PopMessage>();
            if( m != null)
            {
                m.inCameraFocus();
            }
        }
    }
    Camera cam;
    void OnDrawGizmosSelected()
    {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward.normalized * 100);
    }
    void EnableLook()
    {
        this.enabled = true;
    }
}
