using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPick : MonoBehaviour {

    GameObject Quiet;
    GameObject Loud;
    float maxVolume = 0.15f;
    float fadeTime = 3f;
    AudioSource Track1;
    AudioSource Track2;

	// Use this for initialization
	void Start () {
        Quiet = gameObject.transform.GetChild(0).gameObject;
        Loud = gameObject.transform.GetChild(1).gameObject;

        Track1 = Quiet.GetComponent<AudioSource>();
        Track2 = Loud.GetComponent<AudioSource>();

        Track1.volume = 0.15f;
        Track2.volume = 0f;
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKey("n"))
        {
            PickTrack1();
        }

        if (Input.GetKey("m"))
        {
            PickTrack2();
        }

    }

    void PickTrack1()
    {
        while (Track1.volume < 0.15f)
        {
            Track1.volume += Track2.volume * (Time.deltaTime / fadeTime);
        }
        while (Track2.volume > 0f)
        {
            Track2.volume -= Track2.volume * (Time.deltaTime / fadeTime);
        }

    }

    void PickTrack2()
    {
        while (Track2.volume < 0.15f)
        {
            Track2.volume += Track2.volume * (Time.deltaTime / fadeTime);
        }
        while (Track1.volume > 0f)
        {
            Track1.volume -= Track2.volume * (Time.deltaTime / fadeTime);
        }
    }
}
