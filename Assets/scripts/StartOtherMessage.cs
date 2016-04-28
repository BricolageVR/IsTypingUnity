using UnityEngine;
using System.Collections;

public class StartOtherMessage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public GameObject messageTo;
    public string message;
    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
        {
            messageTo.SendMessage(message);
        }
    }
}
