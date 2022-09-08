using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Boid Behaviors/Avoidance")]
public class Avoidance_Beh : Boid_Base_Class
{
    [SerializeField] public float avoidanceRadius = 2;
    public override Vector3 MoveBehavior(Flock_Brain context, Solo_Boid myself)
    {
        Vector3 mainDir = Vector3.zero;

        foreach(Solo_Boid boid in context.activeBoids)
        {
            if (Vector3.Distance(boid.transform.position, myself.transform.position) < avoidanceRadius && boid != myself)
            {
                mainDir += -(boid.transform.position - myself.transform.position) * strength;
            }
        }

        return mainDir;
    }
}
