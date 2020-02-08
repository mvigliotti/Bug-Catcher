using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    // a TerrainGenerator that will generate terrain
    [SerializeField] TerrainGenerator terrainGenerator;

    // Start is called before the first frame update
    void Start()
    {
        instantiateTerrainGenerator();
    }

    // instantiates a TerrainGenerator which will generate the terrain
    void instantiateTerrainGenerator()
    {
        terrainGenerator = Instantiate(terrainGenerator);
        terrainGenerator.name = "TerrainGenerator";
    }

}