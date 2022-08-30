using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of tutorial from Catlikecoding https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/
//I implented the scriptable obejct system to make it more dynamic and change it in real time
public class Test : MonoBehaviour
{
    [SerializeField] GameObject graph;
    [SerializeField] Transform pointPrefab;
    [SerializeField, Range(10, 100)] int resolution = 10;
    Transform[] points;

    [SerializeField] private Wave_Base_Class[] waveBehaviors;

    private void Awake()
    {
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        var scale = Vector3.one * step;

        points = new Transform[resolution * resolution];
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
            }
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (x + 0.5f) * step - 1f;
            position.z = (z + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(graph.transform, false);
        }

        SetUpBehaviors();
    }

    void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = WaveComplier(position.x, position.z, time);
            point.localPosition = position;
        }
    }


    private void SetUpBehaviors()
    {
        foreach(Wave_Base_Class behavior in waveBehaviors)
        {
            behavior.Prerequisite(this);
        }
    }
    private float WaveComplier(float x, float z, float time)
    {
        float yOffset = 0;
        foreach(Wave_Base_Class behavior in waveBehaviors)
        {
            yOffset += behavior.Wave(x, z, time) / waveBehaviors.Length;
        }
        return yOffset;
    }
}
