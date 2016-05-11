using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [SerializeField]
    private string levelName;
    void OnTriggerEnter()
    {
        Application.LoadLevelAsync(levelName);

    }
}
