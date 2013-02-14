﻿using System.Globalization;
using UnityEngine;

[AddComponentMenu("VPL Properties/Native/Rotation Y")]
public class RotY : PhysicsProperty
{
    public override string GetName()
    {
        return "RotY";
    }

    public override string GetValue()
    {
        return transform.rotation.y.ToString(CultureInfo.InvariantCulture);
    }

    public override void SetValue(string val)
    {
        transform.rotation = new Quaternion(
            transform.rotation.x,
            float.Parse(val),
            transform.rotation.z,
            transform.rotation.w
            );
    }
}