using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundTilemapGenerator : MonoBehaviour
{
    // References to the Tilemaps and Tile lists
    public Tilemap groundTilemap; // Tilemap for ground (and roof)
    public List<TileBase> groundTiles;  // List of ground tiles (e.g., dirt, stone, etc.)
    public List<TileBase> roofTiles;    // List of roof tiles
    public int caveWidth = 50;          // Number of tiles along the X-axis
    public int minGroundHeight = 2;     // Minimum height for the ground
    public int maxGroundHeight = 5;     // Maximum height for the ground
    public int gapHeight = 3;           // Height of the gap between the ground and the roof

    private int highestGroundHeight = 0; // Store the highest ground height for roof placement

    // Function to generate the ground and roof
    public void GenerateGroundAndRoof()
    {
        groundTilemap.ClearAllTiles();  // Clear existing tiles
        highestGroundHeight = 0;        // Reset highest ground height

        // Generate the ground tiles along the X-axis
        for (int x = 0; x < caveWidth; x++)
        {
            // Randomly select the height of the ground for this X-position
            int groundHeight = Random.Range(minGroundHeight, maxGroundHeight);

            // Update the highest ground height
            if (groundHeight > highestGroundHeight)
                highestGroundHeight = groundHeight;

            // Place the ground tiles from the base up to the groundHeight
            for (int y = 0; y < groundHeight; y++)
            {
                groundTilemap.SetTile(new Vector3Int(x, y, 0), groundTiles[Random.Range(0, groundTiles.Count)]);
            }

            // Place the roof tiles above the ground at the specified gapHeight
            int roofHeight = highestGroundHeight + gapHeight;

            // Randomly select a roof tile from the roofTiles list
            TileBase selectedRoofTile = roofTiles[Random.Range(0, roofTiles.Count)];

            // Place the roof tile at the correct position
            groundTilemap.SetTile(new Vector3Int(x, roofHeight, 0), selectedRoofTile);
        }
    }

    // Editor button to trigger the ground and roof generation
    [CustomEditor(typeof(GroundTilemapGenerator))]
    public class GroundTilemapGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GroundTilemapGenerator myScript = (GroundTilemapGenerator)target;

            if (GUILayout.Button("Generate Ground and Roof"))
            {
                // Trigger the ground and roof generation when the button is pressed
                myScript.GenerateGroundAndRoof();
            }
        }
    }
}
