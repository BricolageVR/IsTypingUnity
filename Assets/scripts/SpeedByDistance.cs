using UnityEngine;
using System.Collections;

public class SpeedByDistance : MonoBehaviour {

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform self;
    [SerializeField]
    private SphereCollider sc;
    [SerializeField]
    private float dragMass = 1;
    [SerializeField]
    private BasicMovement bm;

	// Use this for initialization
	void Start () {
        bm = player.GetComponent<BasicMovement>();
        sc = GetComponent<SphereCollider>();
        self = this.transform;
	}
	void CalcSpeed()
    {
        float sqrDistance = (player.position - self.position).sqrMagnitude;
        Debug.Log(Mathf.Clamp01(sqrDistance/ sc.radius));
        bm.Speed = BasicMovement.GeneralSpeed * Mathf.Clamp01(sqrDistance / Mathf.Pow(sc.radius,2) * dragMass);
    }
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            CalcSpeed();
        }
    }
}
