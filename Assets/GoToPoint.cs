using UnityEngine;
using System.Collections;

public class GoToPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float xv = transform.position.x, yv = transform.position.y, zv = transform.position.z;
        if(x)
        {
            xv = dest.position.x;
        }
        if (y)
        {
            yv = dest.position.y;
        }
        if (z)
        {
            zv = dest.position.z;
        }
        targetPos = new Vector3(xv, yv, zv);
    }
    public bool x;
    public bool y;
    public bool z;
    public Transform dest;
    private Vector3 targetPos;
    public float speed;
    public float delay;
	// Update is called once per frame
	void Update () {
        StartCoroutine(moveGrad(targetPos));
	}

    IEnumerator moveGrad(Vector3 target)
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);

            if (transform.position == target)
            {
                yield break;
            }

            yield return null;
        }
    }
}
