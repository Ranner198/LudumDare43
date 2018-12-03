using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeaking : MonoBehaviour {

    public AudioClip[] audio;
    private AudioSource audioSource;

    int randomHolder = -99;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayClip", 5, 15);
	}

    void PlayClip() {
        var random = Random.Range(0, audio.Length-1);

        while (random == randomHolder)
            random = Random.Range(0, audio.Length - 1);
    
        audioSource.PlayOneShot(audio[random]);
        randomHolder = random;
    }
}
