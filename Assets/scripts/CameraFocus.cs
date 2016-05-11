using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit info;
        if(Physics.Raycast(transform.position, transform.forward, out info))
        {
            if(info.transform.tag == "lookable")
            {
                PopMessage m = info.transform.GetComponent<PopMessage>();
                if (m != null)
                {
                    Debug.Log("looked");
                    m.inCameraFocus();
                }
            }
        }
    }
    void OnDrawGizmos()
    {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward.normalized * 100);
    }
    void EnableLook()
    {
        this.enabled = true;
    }
}
