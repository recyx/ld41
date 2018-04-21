using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	Vector2[] enemy;

	public float range;

	public void Init (Transform platform) {
		transform.position = platform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
