
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileGrass", menuName = "ScriptableObjects/TileGrass", order = 1)]
public class Grass : Tile
{
    [SerializeField] ABug ant;
    // Start is called before the first frame update
    void Update()
    {

    }

}