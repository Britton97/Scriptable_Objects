using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of tutorial from Catlikecoding https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/
//I implented the scriptable obejct system to make it more dynamic and change it in real time
[CreateAssetMenu(menuName = "Waves / Basic Wave")]
public class WaveForm : Wave_Base_Class
{
    [SerializeField, Range(0, 359)] float rotation;
    private GameObject rotationHandler;
    private float xPos;
    private float zPos;

    public override float Wave(float x, float z, float t)
    {
        rotationHandler.transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
        Vector2 forward = new Vector2(rotationHandler.transform.forward.x, rotationHandler.transform.forward.z);
        xPos = forward.x;
        zPos = forward.y;
        return waveStrength * (Mathf.Sin(Mathf.PI * ((xPos * x) + ((zPos * z) + t))));
    }

    public override void Prerequisite(Test context)
    {
        rotationHandler = new GameObject();
        myParent = GameObject.Find(context.gameObject.name);
        rotationHandler.transform.parent = myParent.transform;
    }
}
