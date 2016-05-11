using UnityEngine;
using System.Collections;

public class ChangeMovementStyle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [SerializeField]
    private MovementMode mode;
    [SerializeField]
    private float speed;
    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
        {
            BasicMovement m = c.GetComponent<BasicMovement>();
            if(m != null)
            {
                m.mode = mode;
                m.Speed = speed;
            }
        }
    }
}
