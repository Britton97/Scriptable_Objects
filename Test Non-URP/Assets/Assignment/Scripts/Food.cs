using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    Flock_Brain brain;
    [SerializeField] private UnityEvent callParticle;
    [SerializeField] private ParticleSystem fx;

    private void Awake()
    {
        brain = GameObject.Find("Flock_Brain").GetComponent<Flock_Brain>();
    }
    private void OnTriggerEnter(Collider other)
    {
        brain.activeFoods.Remove(this);
        callParticle.Invoke();
        fx.Play();
        StartCoroutine(PlayParticles());
    }

    IEnumerator PlayParticles()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
