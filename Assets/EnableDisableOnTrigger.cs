using UnityEngine;
using System.Collections;

public class EnableDisableOnTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public MonoBehaviour[] disable;
    public MonoBehaviour[] enable;
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            for(int i =0;i<disable.Length;i++)
            {
                disable[i].enabled = false;
            }
            for (int i = 0; i < enable.Length; i++)
            {
                enable[i].enabled = true;
            }
        }
    }
}
