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

    // the Bugs that are close to the Player
    IBug[] nearbyBugs;

    // Start is called before the first frame update
    void Start()
    {
        instantiateTerrainGenerator();
        instantiatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        // displays text to pick up a bug if it is close enough
        displayPickupText();
        findNearbyBugs();
    }

    // instantiates a TerrainGenerator which will generate the terrain
    void instantiateTerrainGenerator()
    {
        terrainGenerator = Instantiate(terrainGenerator);
        terrainGenerator.name = "TerrainGenerator";
    }

    // instantiates a Player at the center of the map
    void instantiatePlayer()
    {
        player = Instantiate(player, terrainGenerator.mapCenter(), new Quaternion());
        player.name = "Player";
    }

    // displays a text to pickup a Bug if the Player is close enough
    void displayPickupText()
    {

    }

    // returns a list of Bugs that are currently close to the Player
    GameObject[] findNearbyBugs()
    {
        // find all of the Bugs
        GameObject[] allBugs = GameObject.FindGameObjectsWithTag("Bug");

        // make an array of only the Bugs that are close to the Player
        foreach (GameObject bug in allBugs)
        {
            if ()
        }
    }

}