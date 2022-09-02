using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid Behaviors/Seek Food")]
public class Seek_Food_Beh : Boid_Base_Class
{
    private float orginalStrength;
    private bool moveForward = false;

    private void Awake()
    {
        orginalStrength = strength;
    }

    public override Vector3 MoveBehavior(Flock_Brain context, Solo_Boid myself)
    {
        if (context.activeFoods.Count > 0)
        {
            Vector3 closest = new Vector3(999, 999, 999);
            foreach (Food food in context.activeFoods)
            {
                //find the closest food possible
                if (Vector3.Distance(myself.transform.position, food.transform.position) < Vector3.Distance(myself.transform.position, closest))
                {
                    closest = food.gameObject.transform.position;
                }
            }
            Vector3 direction = closest - myself.transform.position;
            return (direction * strength);
        }
        return Vector3.zero;
    }

    /*
    public override Vector3 MoveBehavior(Flock_Brain context, Solo_Boid myself)
    {
        if (context.activeFoods.Count > 0)
        {
            moveForward = false;
            strength = orginalStrength;
            //GameObject closest = null; //context.activeFoods[0].gameObject;
            Vector3 closest = new Vector3(999, 999, 999);
            float currentClosest = Vector3.Distance(myself.transform.position, closest);
            foreach (Food food in context.activeFoods)
            {
                //search for food that is closer than the default.
                //Check if it is taken. If it is check if you are closer and steal it.
                //else just move forward and set strength to zero
                float newDistance = Vector3.Distance(myself.transform.position, food.transform.position);
                if (newDistance < currentClosest && food.activelyBeingPursued == false || food.targetingMe == myself) //food is closer than closest AND not being pursued OR it is being pursued by itself
                {
                    food.activelyBeingPursued = true;
                    food.targetingMe = myself;
                    closest = food.gameObject.transform.position;
                }
                //food is closer than closest AND food is being pursued AND its distance is smaller than the one actively chasing it.
                else if (newDistance < currentClosest && food.activelyBeingPursued && newDistance < Vector3.Distance(food.targetingMe.transform.position, food.transform.position))
                {
                    food.targetingMe = myself;
                    closest = food.gameObject.transform.position;
                }
                else
                {
                    Debug.Log("Got here");
                    moveForward = true;
                }
            }
            Vector3 direction = closest - myself.transform.position; //this will be a probe
            if(!moveForward) { return (direction * strength); } else { return Vector3.zero; }
        }
        return Vector3.zero;
    }
    */
}
