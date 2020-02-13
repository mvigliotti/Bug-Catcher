﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStrider : ABug
{
    public WaterStrider(string bugName, Gene attack, Gene defense, Gene health, Gene speed, Color color, bool isFire) :
        base(bugName, attack, defense, health, speed, color)
    {

    }
}