using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solo_Boid : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField, Range(0, 1),Tooltip("This will determine the max angle a boid can turn")] float turnLimiter;
    [SerializeField] public List<Boid_Base_Class> boidBehaviors = new List<Boid_Base_Class>();
    [SerializeField] private bool drawDirections = false;

    public void CallBehaviors(Flock_Brain context)
    {
        //starts with a vector3.zero then each behavior will return the direction is wants to go
        //Add directions together then normalize
        Vector3 suggestedMove = Vector3.zero;

        foreach(Boid_Base_Class behavior in boidBehaviors)
        {
            suggestedMove += behavior.MoveBehavior(context, this);
        }
        suggestedMove = suggestedMove.normalized;

        Vector3 limitedAngle = ((suggestedMove * (1 - turnLimiter)) + (transform.forward * turnLimiter)).normalized;

        if (drawDirections) { DrawDirections(suggestedMove, limitedAngle); }

        transform.rotation = Quaternion.LookRotation(limitedAngle);
        transform.position += (transform.forward * moveSpeed * Time.deltaTime);
    }

    public void DrawDirections(Vector3 suggestedMove, Vector3 limitedAngle)
    {
        Debug.DrawRay(transform.position, suggestedMove, Color.red);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        Debug.DrawRay(transform.position, limitedAngle, Color.blue);
    }
}
