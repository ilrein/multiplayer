using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IslandGenerator : MonoBehaviour
{
  //public TileBase waterTile;
  public TileBase grassTile;
  public Tilemap tileMap;

  // Start is called before the first frame update
  void Start()
  {
    GenerateBlock();
  }

  // rules -> super cool
  // massive dynamic width/height
  // intersperse water riles

  void GenerateBlock()
  {
    for (int x = 0; x < 10; x++)
    {
      for (int y = 0; y < 10; y++)
      {
        Debug.Log("setting tile");
        tileMap.SetTile(new Vector3Int(x, y, 0), grassTile);
      }
    }
  }
}
