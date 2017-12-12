using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioClip audioDespawn;
    public AudioClip audioSpawn;
    public AudioClip audioMenu;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn() { //Sound für Objekt Spawn
        audioSource.clip = audioSpawn;
        audioSource.Play();
    }

    public void Despawn() //Sound für Objekt Despawn
    {
        audioSource.clip = audioDespawn;
        audioSource.Play();
    }

    public void Menu() //Sound für Menü Switch
    {
        audioSource.clip = audioMenu;
        audioSource.Play();
    }
}
