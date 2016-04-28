using UnityEngine;
using System.Collections;

public class StartAnimation : MonoBehaviour, IEnable {

    public Animator anim;
    public string booleanName;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool(booleanName, true);

	}
	public void Enable(object data)
    {
        this.enabled = true;
    }
    public void EnableMe()
    {
        this.enabled = true;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
