using UnityEngine;
using System.Collections;

public class ChildPosition : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        self = transform;
        StartCoroutine(Reposition());
	}
    private Transform self;
    [SerializeField]
    private float speed;
    public Vector3 desiredPos;
	public IEnumerator Reposition()
    {
        while((self.localPosition != desiredPos))
        {
            Debug.Log("Waoken");
            self.localPosition = Vector3.MoveTowards(self.localPosition, desiredPos, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
