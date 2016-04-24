using UnityEngine;
using System.Collections;
using System;

public class AddYou : MonoBehaviour,IEnable {

	// Use this for initialization
	void Start () {
        self = transform;
        StartCoroutine(Reposition());
	}

    public IEnumerator Reposition()
    {
        Vector3 desiredPos = refPos.localPosition + direction * distance;
        while ((self.localPosition != desiredPos))
        {
            Debug.Log("Waoken");
            self.localPosition = Vector3.MoveTowards(self.localPosition, desiredPos, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    private Transform self;
    public Transform [] childs;
    public Transform refPos;
    public Vector3 direction = new Vector3(0, 1, 0);
    public float distance;
    public float speed = 1;
	public void Enable(object data)
    {
        this.enabled = true;
        gameObject.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
