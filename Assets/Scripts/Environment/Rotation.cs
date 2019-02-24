using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, Mathf.Sin(Time.time * 10), 0) * Time.deltaTime * 5);
        transform.localScale += (new Vector3(Mathf.Sin(Time.time * 12), Mathf.Sin(Time.time * 12), Mathf.Sin(Time.time * 12)) * Time.deltaTime * 0.5f);
	}
}
