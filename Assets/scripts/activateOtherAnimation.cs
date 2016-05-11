using UnityEngine;
using System.Collections;

public class activateOtherAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public Transform anim;
    public void playAnimation(string boolName)
    {
        anim.GetComponent<Animator>().SetBool(boolName, true);
    }
}
