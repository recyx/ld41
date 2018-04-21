using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

[CreateAssetMenu]
public class PathTileScript : TileBase {

	public Sprite[] top, topRightOuter, topRightInner, right, rightBottomOuter, rightBottomInner, 
	bottom, bottomLeftOuter, bottomLeftInner, left, leftTopOuter, leftTopInner;

	public Sprite m_Sprite;

	public override void RefreshTile(Vector3Int location, ITilemap tilemap) {
		for (int yd = -1; yd < 2; yd++) {
			for (int xd = -1; xd < 2; xd++) {
				Vector3Int position = new Vector3Int (location.x + xd, location.y + yd, location.z);
				if (HasPathTile (tilemap, position)) {
					tilemap.RefreshTile (position);
				}
			}
		}
	}

	public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData) {
		tileData.colliderType = Tile.ColliderType.Grid;

		Random.InitState (location.x * 42 + location.y);
		tileData.sprite = top [Random.Range(0, top.Length)];

		//Right
		if(!HasPathTile(tilemap, location + new Vector3Int(1,0,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,1,0))) {					
			tileData.sprite = right [Random.Range(0, right.Length)];
		}
		//Bottom
		else if(!HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(-1,0,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(1, 0, 0))) {					
			tileData.sprite = bottom [Random.Range(0, bottom.Length)];
		}
		//Left
		else if(!HasPathTile(tilemap, location + new Vector3Int(-1,0,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,1,0))) {					
			tileData.sprite = left [Random.Range(0, left.Length)];
		}
		//leftTopOuter
		else if(!HasPathTile(tilemap, location + new Vector3Int(-1,0,0)) &&
			!HasPathTile(tilemap, location + new Vector3Int(0,1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(1,0,0))) {					
			tileData.sprite = leftTopOuter [Random.Range(0, leftTopOuter.Length)];
		}
		//TopRightOuter
		else if(!HasPathTile(tilemap, location + new Vector3Int(1,0,0)) &&
			!HasPathTile(tilemap, location + new Vector3Int(0,1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(-1,0,0))) {					
			tileData.sprite = topRightOuter [Random.Range(0, topRightOuter.Length)];
		}
		//rightBottomOuter
		else if(!HasPathTile(tilemap, location + new Vector3Int(1,0,0)) &&
			!HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(-1,0,0))) {					
			tileData.sprite = rightBottomOuter [Random.Range(0, rightBottomOuter.Length)];
		}
		//bottomLeftOuter
		else if(!HasPathTile(tilemap, location + new Vector3Int(-1,0,0)) &&
			!HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(1,0,0))) {					
			tileData.sprite = bottomLeftOuter [Random.Range(0, bottomLeftOuter.Length)];
		}
		//leftTopInner
		else if(!HasPathTile(tilemap, location + new Vector3Int(1,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(1,0,0))) {					
			tileData.sprite = leftTopInner [Random.Range(0, leftTopInner.Length)];
		}
		//TopRightInner
		else if(!HasPathTile(tilemap, location + new Vector3Int(-1,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,-1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(-1,0,0))) {					
			tileData.sprite = topRightInner [Random.Range(0, topRightInner.Length)];
		}
		//rightBottomInner
		else if(!HasPathTile(tilemap, location + new Vector3Int(-1,1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(-1,0,0))) {					
			tileData.sprite = rightBottomInner [Random.Range(0, rightBottomInner.Length)];
		}
		//bottomLeftInner
		else if(!HasPathTile(tilemap, location + new Vector3Int(1,1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(0,1,0)) &&
			HasPathTile(tilemap, location + new Vector3Int(1,0,0))) {					
			tileData.sprite = bottomLeftInner [Random.Range(0, bottomLeftInner.Length)];
		}

	}

	public bool HasPathTile(ITilemap tilemap, Vector3Int position) {
		return tilemap.GetTile (position) == this;
	}
}
