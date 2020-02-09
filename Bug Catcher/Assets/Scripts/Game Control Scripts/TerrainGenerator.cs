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
    [SerializeField] Tile tileWater = null, tileSand = null, tileGrass = null, tileThickGrass = null;
    // the Tiles height limits for Perlin Noise
    [SerializeField] float waterHeight = 0f, sandHeight = 0f, grassHeight = 0f;

    // the scale factor for Perlin Noise
    [SerializeField] [Range(0f, 20f)] float perlinScaleFactor = 0f;
    // the offset for Perlin Noise
    float perlinOffsetX = 0f, perlinOffsetY = 0f;

    // Start is called before the first frame update
    void Start()
    {
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
        // the array of Tiles that will be generated
        Tile[,] tiles = new Tile[this.width, this.height];

        // the random x and y positions to generate Perlin Noise
        this.perlinOffsetX = Random.Range(0f, 10000f);
        this.perlinOffsetX = Random.Range(0f, 10000f);

        // for each x-position on the level starting at a random x
        for (int x = 0; x < this.width; x++)
        {
            // for each y-position on the level starting at a random y
            for (int y = 0; y < this.height; y++)
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
        // randomly select an offset for x and y to generate a random map
        Debug.Log(this.perlinOffsetX + " " + this.perlinOffsetY);

        // the given x and y coordinates scaled for Perlin Noise
        float perlinScaledX = (float)x / this.width * this.perlinScaleFactor + this.perlinOffsetX;
        float perlinScaledY = (float)y / this.height * this.perlinScaleFactor + this.perlinOffsetY;

        // the generated height value from Perlin Noise
        float height = Mathf.PerlinNoise(perlinScaledX, perlinScaledY);
        //Debug.Log(height);

        // if the Perlin height is less than the threshold for water tiles, return a:
        // water tile
        if (height < this.waterHeight)
        {
            return this.tileWater;
        }
        // sand tile
        else if (height < this.sandHeight)
        {
            return this.tileSand;
        }
        // grass tile
        else if (height < this.grassHeight)
        {
            return this.tileGrass;
        }
        // thick grass tile
        else
        {
            return this.tileThickGrass;
        }
        
    }
    
}