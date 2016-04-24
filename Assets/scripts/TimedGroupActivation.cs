using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public interface IEnable
{
    void Enable(object obj);
}
[System.Serializable]
public class group
{
    public Transform obj;
    public float delay;
    public float data;
}

public class TimedGroupActivation : MonoBehaviour {

    [SerializeField]
    public List<group> groups;
	// Use this for initialization
	void Start () {
        StartCoroutine(startGrouping());
	}
	IEnumerator startGrouping()
    {
        for(int i =0;i<groups.Count;i++)
        {
            group g = groups[i];
            yield return new WaitForSeconds(g.delay);
            g.obj.GetComponent<IEnable>().Enable(g.data);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
