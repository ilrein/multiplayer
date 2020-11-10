using UnityEngine;
using UnityEngine.Tilemaps;
using Cinemachine;

public class IslandGenerator : MonoBehaviour
{
  public CinemachineVirtualCamera vcam;

  //public TileBase waterTile;
  public TileBase grassTile;
  public Tilemap tileMap;

  // Start is called before the first frame update
  void Start()
  {
    GenerateBlock();
  }

  void Update()
  {
  }

  // rules -> super cool
  // massive dynamic width/height
  // intersperse water riles

  void GenerateBlock()
  {
    for (int x = -100; x < 100; x++)
    {
      for (int y = -100; y < 100; y++)
      {
        tileMap.SetTile(new Vector3Int(x, y, 0), grassTile);
      }
    }
  }
}
