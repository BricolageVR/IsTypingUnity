using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [SerializeField]
    private Transform animationRef;
    [SerializeField]
    private string boolName;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            animationRef.GetComponent<Animator>().SetBool(boolName, true);
        }
    }
}
