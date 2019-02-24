using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

    CharacterStats HealObject;
    float SpawnTimer;
    bool inactive = false;

    Renderer rend;
    Collider coli;
    AudioSource Audi;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        coli = GetComponent<Collider>();
        Audi = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (inactive)
        {
            SpawnTimer += Time.deltaTime;
            if (SpawnTimer > 10f)
            {
                rend.enabled = true;
                coli.enabled = true;
                SpawnTimer = 0f;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            HealObject = other.gameObject.GetComponent<PlayerStats>();
            HealObject.Heal(50);
            Audi.Play();
            inactive = true;
        }
        rend.enabled = false;
        coli.enabled = false;

    }


}
