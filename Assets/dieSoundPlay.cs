using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieSoundPlay : MonoBehaviour {

    public AudioSource sound;
	// Update is called once per frame
	public void soundgame () {
        if (FindObjectOfType<GameManager>().gameHasEnded)
        {
            sound.Play();
        }
		
	}
}
