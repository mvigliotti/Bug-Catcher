using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : ABug
{
    bool isFire; // is this ant a fire ant?

    public Ant(string bugName, Gene attack, Gene defense, Gene health, Gene speed, Color color, bool isFire):
        base(bugName, attack, defense, health, speed, color)
    {
        this.isFire = isFire;
    }
}
