using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform platform;

	public float range;

	// Use this for initialization
	void Start () {
		transform.position = platform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
