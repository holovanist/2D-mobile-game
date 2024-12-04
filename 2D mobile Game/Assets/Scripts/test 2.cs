using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class BackgroundTilemap : MonoBehaviour
{
    public Tilemap backgroundTilemap; // Reference to the Tilemap for the background
    public List<TileBase> backgroundTiles; // List of background tiles (e.g., cave walls, rocks, etc.)
    public int mapWidth = 50;      // Width of the cave
    public int mapHeight = 20;     // Height of the cave

    void Start()
    {
        GenerateBackground();
    }

    public void GenerateBackground()
    {
        int backgroundTileIndex = 0; // Start from the first tile in the backgroundTiles list

        // Loop through each position in the tilemap (covering the entire height and width)
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // Randomly select a tile from the backgroundTiles list for each position
                TileBase selectedBackgroundTile = backgroundTiles[backgroundTileIndex];

                // Set the background tile at the current position (x, y)
                backgroundTilemap.SetTile(new Vector3Int(x, y, 0), selectedBackgroundTile);

                // Move to the next tile in the backgroundTiles list (cycling through)
                backgroundTileIndex = (backgroundTileIndex + 1) % backgroundTiles.Count;
            }
        }
    }
}
