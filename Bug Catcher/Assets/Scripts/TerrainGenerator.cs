using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGenerator : MonoBehaviour
{
    // the Grid and its Tilemap that will store terrain tile information
    [SerializeField] Grid terrainGrid;
    [SerializeField] Tilemap terrainTilemap;

    // the width (x) and height (y) of the level
    [SerializeField] int width = 0, height = 0;
    // the starting location of the level
    int startX, startY;

    // the Tiles to be added to the Tilemap
    [SerializeField] Tile tileWater = null, tileSand = null, tileGrass = null, tileThickGrass = null, tileBush = null;
    // the Tiles height limits for Perlin Noise
    [SerializeField] float waterHeight = 0f, sandHeight = 0f, grassHeight = 0f, thickGrassHeight = 0f;

    // the scale factor for Perlin Noise
    [SerializeField] [Range(0f, 1f)] float perlinScaleFactor = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.startX);
        this.instantiateTerrainGrid();
        this.setTilesInTilemap(this.generateTileArrayTerrain());
    }

    // instantiates the terrainGrid and a terrainTilemap as its child
    void instantiateTerrainGrid()
    {
        this.terrainGrid = Instantiate(terrainGrid);
        this.terrainGrid.name = "TerrainGrid";
        this.terrainTilemap = Instantiate(terrainTilemap, terrainGrid.transform);
        this.terrainTilemap.name = "TerrainTilemap";
    }

    // assigns each tile in terrainGrid to a type of terrain Tile
    void setTilesInTilemap(Tile[,] tiles)
    {

        // for each x-position on the level
        for (int x = 0; x < this.width; x++)
        {
            // for each y-position on the level
            for (int y = 0; y < this.height; y++)
            {
                // set the tile of the given location as the given tile type
                terrainTilemap.SetTile(new Vector3Int(x, y, 0), tiles[x, y]);
            }
        }
    }
    
    // generates a terrain map with Perlin Noise
    Tile[,] generateTileArrayTerrain()
    {
        // find a new x and y-position on the map to generate random Perlin Noise
        -this.startX = (int)(Random.value * 1000000f);

        // the array of Tiles that will be generated
        Tile[,] tiles = new Tile[this.width, this.height];

        // for each x-position on the level starting at a random x
        for (int x = this.startX; x < this.startX + this.width; x++)
        {
            // for each y-position on the level starting at a random y
            for (int y = this.startY; y < this.startY + this.height; y++)
            {
                // set the tile at that position to a Perlin-Noise generated tile
                tiles[x, y] = generateTileWithPerlinNoise(x, y);
            }
        }
        return tiles;
    }

    // makes computations with Perlin Noise to select a tile to place at the given location
    Tile generateTileWithPerlinNoise(int x, int y)
    {
        // the given x and y coordinates scaled for Perlin Noise
        float perlinScaledX = x * this.perlinScaleFactor;
        float perlinScaledY = y * this.perlinScaleFactor;

        // the generated height value from Perlin Noise
        float height = Mathf.PerlinNoise(perlinScaledX, perlinScaledY);
        
        if (height < this.waterHeight)
        {
            return this.tileWater;
        }
        else if (height < this.sandHeight)
        {
            return this.tileSand;
        }
        else if (height < this.grassHeight)
        {
            return this.tileGrass;
        }
        else if (height < this.thickGrassHeight)
        {
            return this.tileThickGrass;
        }
        else
        {
            return this.tileBush;
        }
        
    }
    
}