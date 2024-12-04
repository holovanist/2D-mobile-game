using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundTilemapGenerator : MonoBehaviour
{
    // References to the Tilemaps and Tile lists
    public Tilemap backgroundTilemap; // Tilemap for the cave background (walls)
    public TileBase wallTile;   // Tile for the cave walls
    public int caveWidth = 50;  // Number of tiles along the X-axis
    public int maxGroundHeight = 5; // Maximum height of the ground (determines roof's height)
    public int gapHeight = 3; // Height of the gap between the ground and the roof

    // Reference to the GroundTilemapGenerator to get the highest ground height
    public GroundTilemapGenerator groundGenerator;

    // Function to generate the background (walls) of the cave
    public void GenerateBackground()
    {
        backgroundTilemap.ClearAllTiles();  // Clear existing tiles

        // Get the highest ground height from the GroundTilemapGenerator
        int highestGroundHeight = 1; //groundGenerator.HighestGroundHeight();

        // Generate the walls (background) for the entire cave
        for (int x = 0; x < caveWidth; x++)
        {
            // Generate walls for the cave at the sides (left and right)
            for (int y = -5; y < highestGroundHeight + gapHeight; y++)  // Background walls fill space
            {
                backgroundTilemap.SetTile(new Vector3Int(x, y, 0), wallTile);
            }
        }
    }

    // Editor button to trigger the background (walls) generation
    [CustomEditor(typeof(BackgroundTilemapGenerator))]
    public class BackgroundTilemapGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            BackgroundTilemapGenerator myScript = (BackgroundTilemapGenerator)target;

            if (GUILayout.Button("Generate Background (Walls)"))
            {
                // Trigger the background generation when the button is pressed
                myScript.GenerateBackground();
            }
        }
    }
}
