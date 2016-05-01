using UnityEngine;
using System.Collections;

public class PopMessage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        once = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [SerializeField]
    private Transform messagePopUp;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private bool once;
    public void inCameraFocus()
    {
        if(!once)
        {
            //Play destruction animation
            //GetComponent<Animator>().SetBool("focused", true);
            //Instantiate(messagePopUp, transform.position + offset, transform.rotation);
            //once = true;
            //the popup message object should destroy itself 
            //the destruction of the current message should be called from the animation interface
        }
    }

    public void destructSelf()
    {
        Destroy(gameObject);
    }
}
