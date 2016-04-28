using UnityEngine;
using System.Collections;

public class Subgroup : MonoBehaviour,IEnable {

    [SerializeField]
    private float nextChildOffset = 0.2f;
    public float NextChildOffset { get { return nextChildOffset; } }
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    public Vector3 Direction { get { return direction; } }
    public void Enable(object data)
    {
        this.enabled = true;
    }
    // Use this for initialization
    void Start () {
        EnableSubGroups();
	}
    private void EnableSubGroups()
    {
        Vector3 normDirection = direction.normalized;
        Transform self = transform;
        int childCount = self.childCount;
        Transform parent = self.parent;
        Vector3 currPos = offset + normDirection * nextChildOffset * ((int)(childCount/2));
        for (int i = 0; i < childCount; i++)
        {
            Transform child = self.GetChild(0);
            child.SetParent(parent);
            child.GetComponent<ChildPosition>().desiredPos = currPos;
            child.gameObject.SetActive(true);
            currPos -= normDirection * nextChildOffset;
        }
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
