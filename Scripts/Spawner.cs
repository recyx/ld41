using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] enemyPrefab;
	public GameObject[] turretPrefab;

	GameObject platforms;
	Transform[] platform;

	GameObject Turrets;
	GameObject enemies;

	Turret newTurret;
	Enemy newEnemy;

	List<Enemy> enemyPosition = new List<Enemy>();
	List<Turret> turrets = new List<Turret>();

	// Use this for initialization
	void Start () {

		Turrets = GameObject.Find ("Turrets");
		enemies = GameObject.Find ("Enemies");

		platforms = GameObject.Find ("Platforms");
		platform = new Transform[platforms.transform.childCount];

		for (int i = 0; i < platforms.transform.childCount; i++) {
			platform[i] = platforms.transform.GetChild (i).transform;
		}
			
		SpawnTurret (0, 0);
		SpawnTurret (1, 0);
		SpawnEnemy (0);
		SpawnEnemy (1);
		SpawnEnemy (2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy(int type) {
		newEnemy = (Instantiate (enemyPrefab [type], enemies.transform) as GameObject).GetComponent<Enemy> ();
		enemyPosition.Add (newEnemy);
		UpdateTurrets ();
	}

	public void DeleteEnemy(Enemy target) {
		enemyPosition.Remove (target);
		UpdateTurrets ();
	}

	void SpawnTurret(int index, int type) {
		newTurret = (Instantiate (turretPrefab [type], platform [index].position, platform [index].rotation, Turrets.transform) as GameObject).GetComponent<Turret> ();
		newTurret.Init (platform [index]);
		newTurret.UpdateEnemyTransforms (enemyPosition);

		turrets.Add (newTurret);
	}

	void UpdateTurrets() {
		foreach (Turret turret in turrets) {
			turret.UpdateEnemyTransforms (enemyPosition);
		}
	}

}
