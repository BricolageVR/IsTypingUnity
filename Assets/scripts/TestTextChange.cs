using UnityEngine;
using System.Collections;

public class TestTextChange : MonoBehaviour {

    public Transform[] texts;
   
	// Use this for initialization
	void Start () {
	    for(int i =0;i<texts.Length;i++)
        {
            texts[i].GetComponent<TextMesh>().text = "this is a text example";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
