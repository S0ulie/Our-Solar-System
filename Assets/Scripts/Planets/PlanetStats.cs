using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make a class for the different planets' stats
public class PlanetStats
{
    public string name;
    public string description;

    public int diameter;
    public int temperature;
    public float gravity;
    public int numMoons;
    public double kmFromSun;

    public PlanetStats(string newName, string newDescription, int newDiameter,
                        int newTemperature, float newGravity, int newNumMoons,
                        double newKmFromSun)
    {
        name = newName;
        description = newDescription;
        diameter = newDiameter;
        temperature = newTemperature;
        gravity = newGravity;
        numMoons = newNumMoons;
        kmFromSun = newKmFromSun;
    }
}