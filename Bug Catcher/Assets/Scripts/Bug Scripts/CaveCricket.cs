using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCricket : ABug
{
    public CaveCricket(string bugName, Gene attack, Gene defense, Gene health, Gene speed, Color color, bool isFire) :
        base(bugName, attack, defense, health, speed, color)
    {

    }
}
