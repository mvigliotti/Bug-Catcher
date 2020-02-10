using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABug : MonoBehaviour, IBug
{
    string bugName; // the bug's name
    Gene attack, defense, health, speed; // the bug's genes
    Color color; // the bug's color

    public ABug(string bugName, Gene attack, Gene defense, Gene health, Gene speed, Color color)
    {
        this.bugName = bugName;
        this.attack = attack;
        this.defense = defense;
        this.health = health;
        this.speed = speed;
        this.color = color;
    }
}
