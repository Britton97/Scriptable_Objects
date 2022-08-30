using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based off of tutorial from Catlikecoding https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/
//I implented the scriptable obejct system to make it more dynamic and change it in real time
[CreateAssetMenu(menuName = "Waves / Ripple")]
public class RippleForm : Wave_Base_Class
{
    [SerializeField, Range(0, 359)] float rotation;
    private GameObject rotationHandler;
    [SerializeField] public Vector2 offset;
    public override float Wave(float x, float z, float t)
    {
        x = x + offset.x;
        z = z + offset.y;
        float d = Mathf.Sqrt(x * x + z * z);
        float y = Mathf.Sin(Mathf.PI * (4f * d - t));
        return waveStrength * (y / (1f + 10f * d));
    }

    public override void Prerequisite(Test context)
    {
        rotationHandler = new GameObject();
        myParent = GameObject.Find(context.gameObject.name);
        rotationHandler.transform.parent = myParent.transform;
    }
}
