using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    Flock_Brain brain;
    private void Awake()
    {
        brain = GameObject.Find("Flock_Brain").GetComponent<Flock_Brain>();
    }
    private void OnTriggerEnter(Collider other)
    {
        brain.activeFoods.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
