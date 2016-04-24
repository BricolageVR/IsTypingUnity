using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Utility;


public class PositionGroups : MonoBehaviour {

    private const int MAX_GROUPS_NUM = 5;
    [SerializeField]
    private Transform [] groupObjects;
    [SerializeField]
    private Transform followTarget;
    /// <summary>
    /// PreSets for the offsets of the groups.
    /// the number of the groups is 0 - 5.
    /// </summary>
    [Header("Group objects positions list:")]
    [SerializeField]
    private Vector3[] offsets =
    {
        new Vector3(0.15f,2,3.5f),
        new Vector3(3,0,1.4f),
        new Vector3(-3,0,1.4f),
        new Vector3(3.3f,1,2.6f),
        new Vector3(-3.3f,1,2.6f)
    };
	// Use this for initialization
	void Start () {
	    for(int i = 0;i<groupObjects.Length && i < MAX_GROUPS_NUM; i++)
        {
            FollowTarget followScript = groupObjects[i].GetComponent<FollowTarget>();
            followScript.target = followTarget;
            followScript.offset = offsets[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
