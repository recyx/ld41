using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

[CreateAssetMenu]
public class GroundTileScript : TileBase {

	public Sprite defaultSprite;
	public Sprite[] details;
	[Range(0, 1)]
	public float detailProbability;

	public Sprite m_Sprite;

	public override void RefreshTile(Vector3Int location, ITilemap tilemap) {
		tilemap.RefreshTile (location);
	}

	public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData) {
		tileData.colliderType = Tile.ColliderType.Grid;

		Random.InitState (("Seed: x: " + location.x * 42 + " - y: " + location.y * 42).GetHashCode());
		tileData.sprite = defaultSprite;

		if (details.Length > 0 && Random.value < detailProbability) {
			tileData.sprite = details [Random.Range (0, details.Length)];
		}

	}
}