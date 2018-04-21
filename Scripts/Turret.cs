using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public float range;
	public float damage;
	public int targetCount;

	List<Enemy> enemies = new List<Enemy>();

	public void Init (Transform platform) {
		transform.position = platform.position;
	}

	void Start () {
	}

	void Update () {
		ScanEnemies ();
	}

	public void UpdateEnemyTransforms (List<Enemy> updatedEnemyTransforms) {
		enemies.Clear();
		enemies = new List<Enemy>(updatedEnemyTransforms.Count);

		foreach (Enemy enemy in updatedEnemyTransforms) {
			enemies.Add (enemy);
		}
	}

	void ScanEnemies() {
		int availableTargets = targetCount;
			
		foreach (Enemy enemy in enemies) {
			if ((enemy.transform.position - transform.position).magnitude < range) {

				if (availableTargets < 1) {
					print ("too many!");
					return;
				}

				availableTargets--;
				AttackEnemy (enemy);
			}
		}
	}

	void AttackEnemy(Enemy enemy) {
		Debug.DrawLine (transform.position, enemy.transform.position, Color.red);
		enemy.Damage (damage * Time.deltaTime);
	}
}
