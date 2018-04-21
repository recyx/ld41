using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	public float speed;
	public float health;

	GameObject waypoints;
	Transform[] waypoint;

	Vector2 direction;

	int currentWaypoint = 0;


	void Start () {
		waypoints = GameObject.Find ("Waypoints");
		waypoint = new Transform[waypoints.transform.childCount];

		for (int i = 0; i < waypoints.transform.childCount; i++) {
			waypoint[i] = waypoints.transform.GetChild (i).transform;
		}

		transform.position = waypoint [0].position;
	}
	
	void Update () {
		
		if ((transform.position - waypoint [currentWaypoint].position).magnitude < 0.1f) {
			transform.position = waypoint [currentWaypoint].position;

			if (currentWaypoint + 1 >= waypoint.Length) {
				End ();
				return;
			}

			currentWaypoint++;
			direction = (waypoint [currentWaypoint].position - transform.position).normalized;
		}


		transform.Translate (direction * speed * Time.deltaTime);
		
	}

	void End () {
		Destroy (gameObject);
	}
}
