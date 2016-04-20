using UnityEngine;
using System.Collections;

public class SetObjProportions : MonoBehaviour {

    private const float yCorrectionCofficient = 0.3f;
    private const float scaleCorrectionCofficient = 0.1f;
    private readonly Vector3 cameraCorrectionCofficient = new Vector3(0, -0.675f, -0.0805f);
    //private const float zCameraCorrectionCofficient = -0.0805f;
    //private const float yCameraCorrectionCofficient = -0.675f;

    private const float labelYSize = 1.24f;
    public Transform OVR_CamRef;
    public Transform[] labels;
    public Vector2 distanceRange;
    public float topPos;
	// Use this for initialization
	void Start () {
        //Pre Sets - Do not change!!
        float nextY = topPos;
        float z = 0;
        for (int i = 0; i < labels.Length; i++)
        {
            z = (int)Random.Range(distanceRange.x, distanceRange.y);
            Vector3 screen = Camera.main.WorldToScreenPoint(new Vector3(0, nextY, 0));
            Vector3 world = Camera.main.ScreenToWorldPoint(new Vector3(screen.x,screen.y,10.0805f + z));
            Debug.Log(screen);
            labels[i].position = new Vector3(0,world.y, z);
            labels[i].localScale += new Vector3(0, (z * scaleCorrectionCofficient), z*scaleCorrectionCofficient);
            nextY -= labelYSize;
        }

        OVR_CamRef.position += cameraCorrectionCofficient;
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
