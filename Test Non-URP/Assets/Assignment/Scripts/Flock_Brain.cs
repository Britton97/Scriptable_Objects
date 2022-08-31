using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock_Brain : MonoBehaviour
{
    [Header("General Spawning")]
    [SerializeField, Range(5,50)] private float spawnRadius = 20;

    [Header("Boid Settings")]
    [SerializeField, Range(1,100)] private int boid_amount = 5;
    [SerializeField] private GameObject boid;
    private List<Solo_Boid> activeBoids = new List<Solo_Boid>();

    [Header("Food Settings")]
    [SerializeField, Range(1,500)] private int food_amount = 50;
    [SerializeField] private GameObject food;
    public List<GameObject> activeFoods = new List<GameObject>();

    private void Awake()
    {
        SpawnBoids();
        SpawnFood();
    }

    private void FixedUpdate()
    {
        Boid_Iterator();
    }

    private void Boid_Iterator()
    {
        foreach(Solo_Boid boid in activeBoids)
        {
            boid.CallBehaviors(this);
        }
    }
    private void SpawnBoids()
    {
        //Spawns boids and put this into a list of active boids
        //Also calls the setup function so the boids can be aware of the information in this class
        for (int i = 0; i < boid_amount; i++)
        {
            Vector3 objPos = transform.position + (Random.insideUnitSphere * spawnRadius);
            GameObject thisObj = Instantiate(boid, transform.position, Quaternion.identity);
            thisObj.transform.position = objPos;
            thisObj.transform.rotation = Random.rotation;

            Solo_Boid currentBoid = thisObj.GetComponent<Solo_Boid>();
            activeBoids.Add(currentBoid);
        }
    }

    private void SpawnFood()
    {
        for (int i = 0; i < food_amount; i++)
        {
            Vector3 objPos = transform.position + (Random.insideUnitSphere * spawnRadius);
            GameObject thisObj = Instantiate(food, transform.position, Quaternion.identity);
            thisObj.transform.position = objPos;
            thisObj.transform.rotation = Random.rotation;
            activeFoods.Add(thisObj);
        }
    }



    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
#endif
    }
}
