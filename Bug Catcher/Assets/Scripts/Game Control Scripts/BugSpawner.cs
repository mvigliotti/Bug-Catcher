using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BugSpawner : MonoBehaviour
{
    // a reference to the Tilemap
    Tilemap tilemap;

    // the Bugs that can be spawned
    [SerializeField] ABug ant = null, bee, caveCricket, dragonfly, herculesBeetle, orbWeaver, prayingMantis, scorpion, waterStrider;

    // Start is called before the first frame update
    void Start()
    {
        // sets up a reference to the Tilemap
        this.setupReferenceToTilemap();

        this.maybeSpawnBugs();
    }

    private void Update()
    {
        // spawns Bugs if the conditions are right
        //this.maybeSpawnBugs();
    }

    // sets up a reference to the Tilemap
    void setupReferenceToTilemap()
    {
        this.tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
    }

    // makes a list of the locations of the tiles of the given type
    // The tileType is the name of the tile with the prefix 'Tile' (ex. "TileSand")
    List<Vector3Int> listOfTileType(string tileType)
    {
        List<Vector3Int> tilesOfType = new List<Vector3Int>(); // the list of tile locations of the given type

        // for every position in the tilemap
        for (int x = 0; x < this.tilemap.size.x; x++)
        {
            for (int y = 0; y < this.tilemap.size.y; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                string tileName = this.tilemap.GetTile(tilePos).name;

                // if the name of the tile at the current location equals the given tile name
                if (tileName.Equals(tileType))
                {
                    // add it to the list
                    tilesOfType.Add(tilePos);
                }
            }
        }

        return tilesOfType;

    }

    void maybeSpawnBugs()
    {
        foreach (Vector3Int vector3Int in this.listOfTileType("TileSand"))
        {
            float rate = UnityEngine.Random.Range(0, 100);
            Debug.Log(rate);
            if (rate < 1)
            {
                Instantiate(this.ant, vector3Int, new Quaternion());
            }
        }
    }

}