using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid Behaviors/Seek Food")]
public class Seek_Food_Beh : Boid_Base_Class
{
    public override Vector3 MoveBehavior(Flock_Brain context, Solo_Boid myself)
    {
        GameObject closest = context.activeFoods[0].gameObject;
        foreach(GameObject food in context.activeFoods)
        {
            //find the closest food possible
            if(Vector3.Distance(myself.transform.position, food.transform.position) < Vector3.Distance(myself.transform.position, closest.transform.position))
            {
                closest = food;
            }
        }
        Vector3 direction = closest.transform.position - myself.transform.position;
        return (direction * strength);
    }
}
