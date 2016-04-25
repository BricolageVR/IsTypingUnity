using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System;

public class AddYou : MonoBehaviour,IEnable {

	// Use this for initialization
	void Start () {
        self = transform;
        StartCoroutine(Reposition());
	}
    [SerializeField]
    private Transform nextParent;
    public IEnumerator Reposition()
    {
        float offset = groupParent.GetComponent<Subgroup>().NextChildOffset;
        Vector3 direction = groupParent.GetComponent<Subgroup>().Direction.normalized;
        getChilds();
        Debug.Log(childs.Count);
        Vector3 desiredPos = childs[position].localPosition;
        nextParent.gameObject.SetActive(true);
        for(int i = 0;i<childs.Count;i++)
        {
            childs[i].parent = nextParent;
        }
        for(int i = childs.Count-1;i>=position; i--)
        {
            StartCoroutine(RepositionChild(childs[i], childs[i].localPosition - offset  * direction));
        }
        while ((self.localPosition != desiredPos))
        {
            self.localPosition = Vector3.MoveTowards(self.localPosition, desiredPos, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator RepositionChild(Transform c,Vector3 desiredPos)
    {
        while ((c.localPosition != desiredPos))
        {
            c.localPosition = Vector3.MoveTowards(c.localPosition, desiredPos, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    private Transform self;
    private List<Transform> childs;
    [SerializeField]
    private Transform groupParent;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private int position;
	public void Enable(object data)
    {
        this.enabled = true;
        gameObject.SetActive(true);
        position = Convert.ToInt32(data);
    }

    private void getChilds()
    {
        Transform parent = self.parent;
        childs = new List<Transform>();
        for(int i =0;i < parent.childCount;i++)
        {
            Transform c = parent.GetChild(i);
            if (!c.Equals(self) && c.gameObject.activeInHierarchy)
            {
                childs.Add(c);
            }
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
