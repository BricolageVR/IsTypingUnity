using UnityEngine;
using System.Collections;

public class selfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //if (instances <= 5)
        //{
        //    Instantiate(letters, transform.position + offset, Quaternion.Euler(90,0,0));
        //}
        //instances++;
        //GetComponent<Animator>().SetBool("destruct", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [SerializeField]
    private float delay;
    [SerializeField]
    private Transform letters;
    [SerializeField]
    public static int instances;
    [SerializeField]
    private Vector3 offset;
    void destruct()
    {
        Destroy(gameObject);
    }
}
