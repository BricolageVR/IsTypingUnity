using UnityEngine;
using System.Collections;

public class CrystalFloat : MonoBehaviour {

    [SerializeField]
    [Range(0, 5)]
    private float maxHeight;
    [SerializeField]
    [Range(0, 100)]
    private float speed;
    // Use this for initialization

    private float x;
    private float z;
	void Start () {
        x = transform.position.x;
        z = transform.position.z;
        maxHeight = Random.Range(0.5f, 1.5f);
        speed = Random.Range(1, 3f);

    }
	
	// Update is called once per frame
	void Update () {
        float height = maxHeight * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(x,height,z);
	
	}
}
