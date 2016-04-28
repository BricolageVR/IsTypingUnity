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
            Transform parent = info.transform.parent;
            if(parent != null)
            {
                Debug.Log(parent.name);
                PopMessage m = parent.GetComponent<PopMessage>();
                if (m != null)
                {
                    m.inCameraFocus();
                }
            }
        }
    }
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
