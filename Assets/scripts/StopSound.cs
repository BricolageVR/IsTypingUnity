﻿using UnityEngine;
using System.Collections;

public class StopSound : MonoBehaviour {
    public AudioSource[] sounds;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void stopSound(int index)
    {
        sounds[index].Stop();
    }
}
