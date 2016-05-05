using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    [SerializeField]
    private AudioSource[] clips;
    [SerializeField]
    private ulong delay;
    // Use this for initialization
    void Start () {
	    
	}
	
    public void playSound(int index)
    {
        clips[index].Play(delay);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
