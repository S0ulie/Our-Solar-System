using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create a scriptable object for the different planets

[CreateAssetMenu(fileName = "New Planet", menuName = "Planet")]
public class Planet : ScriptableObject
{
    public new string name;

    public Sprite graphic;
}
