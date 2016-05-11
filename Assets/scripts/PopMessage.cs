using UnityEngine;
using ArabicSupport;
using System.Collections;

public class PopMessage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        once = false;
        GetComponent<Renderer>().material.color = Color.black;
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
    [SerializeField]
    public string text;
    [Range(0, 100)]
    public int charge;
    public void inCameraFocus()
    {
        if(!once)
        {
            //Play destruction animation
            //GetComponent<Animator>().SetBool("focused", true);
            charge += 3;
            GetComponent<Renderer>().material.color += Color.white * 0.03f;
            if(charge >= 100)
            {
                Transform t = (Transform)Instantiate(messagePopUp, transform.position + offset, Quaternion.identity);
                t.GetChild(0).GetComponent<TextMesh>().text = text;
                this.enabled = false;
                once = true;
            }
            //the popup message object should destroy itself 
            //the destruction of the current message should be called from the animation interface
        }
    }

    //public void destructSelf()
    //{
    //    Destroy(gameObject);
    //}
}
