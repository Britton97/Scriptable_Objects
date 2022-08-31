using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid_Test : MonoBehaviour
{
    [SerializeField, Range(0,100)] private float moveSpeed;
    [SerializeField] GameObject food;
    [SerializeField, Range(0,1)] float turnLimiter;
    [SerializeField, Range(0,5)] float eatFoodRadius = .5f;


    private void Awake()
    {
        food = GameObject.Find("Interest");
    }
    private void Update()
    {
        if (food != null)
        {
            Testing();
            Movement();
        }

    }

    private void Testing()
    {
        //need current direction
        //need to somehow to change the wanted direction to limit how much it can turn each frame
        Vector3 angle = (food.transform.position - transform.position).normalized; //grabbed the direction
        Vector3 forward = transform.forward.normalized;
        float difference = Vector3.Distance(angle, forward);
        Debug.Log(difference);

        Vector3 limitedAngle = ((angle * (1 - turnLimiter)) + (forward * turnLimiter)).normalized;

        Debug.DrawRay(transform.position, angle, Color.red);
        Debug.DrawRay(transform.position, forward, Color.green);
        Debug.DrawRay(transform.position, limitedAngle, Color.blue);
        transform.rotation = Quaternion.LookRotation(limitedAngle);
    }

    private void Movement()
    {
        transform.position += (transform.forward * moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, food.transform.position) < eatFoodRadius)
        {
            Destroy(food);
        }
    }
    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, spawnRadius);
#endif
    }
}
