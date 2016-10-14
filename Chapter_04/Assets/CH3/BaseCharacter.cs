using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class BaseCharacter
{
    [SerializeField]
    private string name;
    [SerializeField]
    private string description;

    [SerializeField]
    private float strength;
    [SerializeField]
    private float defense;
    [SerializeField]
    private float dexterity;
    [SerializeField]
    private float intelligence;
    [SerializeField]
    private float health;



    public string NAME
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string DESCRIPTION
    {
        get { return this.description; }
        set { this.description = value; }
    }

    public float STRENGTH
    {
        get { return this.strength; }
        set { this.strength = value; }
    }

    public float DEFENSE
    {
        get { return this.defense; }
        set { this.defense = value; }
    }

    public float DEXTERITY
    {
        get { return this.dexterity; }
        set { this.dexterity = value; }
    }

    public float INTELLIGENCE
    {
        get { return this.intelligence; }
        set { this.intelligence = value; }
    }

    public float HEALTH
    {
        get { return this.health; }
        set { this.health = value; }
    }
}
