using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid Behaviors/Center")]
public class Center_Beh : Boid_Base_Class
{
    public override Vector3 MoveBehavior(Flock_Brain context, Solo_Boid myself)
    {
        float distanceFromCenter = Vector3.Distance(context.transform.position, myself.transform.position);
        if (distanceFromCenter > context.spawnRadius)
        {
            Vector3 direction = (context.transform.position - myself.transform.position) * strength * (distanceFromCenter - context.spawnRadius);
            return direction;
        }
        return Vector3.zero;
    }
}
