using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    // a TerrainGenerator that will generate terrain
    [SerializeField] TerrainGenerator terrainGenerator;

    // the player
    [SerializeField] Player player;

    // a BugSpawner that will spawn Bugs
    [SerializeField] BugSpawner bugSpawner;

    // Start is called before the first frame update
    void Start()
    {
        instantiateTerrainGenerator();
        instantiateBugSpawner();
        instantiatePlayer();
    }

    // instantiates a TerrainGenerator which will generate the terrain
    void instantiateTerrainGenerator()
    {
        terrainGenerator = Instantiate(terrainGenerator);
        terrainGenerator.name = "TerrainGenerator";
    }

    // instantiates a BugSpawner which will spawn Bugs
    void instantiateBugSpawner()
    {
        bugSpawner = Instantiate(bugSpawner);
        bugSpawner.name = "BugSpawner";
    }

    // instantiates a Player at the center of the map
    void instantiatePlayer()
    {
        player = Instantiate(player, terrainGenerator.mapCenter(), new Quaternion());
        player.name = "Player";
    }

    // gets an array of GameObjects that have the tag 'Bug'
    public GameObject[] existingBugs()
    {
        GameObject[] bugs = GameObject.FindGameObjectsWithTag("Bug"); // the array of bugs in the game
        return bugs; // return the list of bugs in the game
    }

}