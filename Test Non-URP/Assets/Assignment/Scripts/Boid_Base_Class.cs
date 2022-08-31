using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boid_Base_Class : ScriptableObject
{
    [SerializeField, Range(0, 1)] public float strength;
    public abstract Vector3 MoveBehavior(Flock_Brain context, Solo_Boid myself);
}