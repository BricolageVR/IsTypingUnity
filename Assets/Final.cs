using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [SerializeField]
    private Transform plane;
    [SerializeField]
    private Material skybox;
    [SerializeField]
    private GameObject waterfall;
    [SerializeField]
    private float delay = 1;
    IEnumerator finalize()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<BasicMovement>().Speed = 0;
        RenderSettings.skybox = skybox;
        waterfall.SetActive(true);
    }
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "final")
        {
            plane.GetComponent<Animator>().SetBool("change", true);
      
            StartCoroutine(finalize());
        }
    }
}
