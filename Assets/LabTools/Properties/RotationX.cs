﻿using System.Globalization;
using UnityEngine;

[AddComponentMenu("VPL Properties/Native/Rotation X")]
public class RotationX : AbstractProperty
{
    public override string GetName()
    {
        return "RotatX";
    }

    public override string GetValue()
    {
        return transform.rotation.x.ToString(CultureInfo.InvariantCulture);
    }

    public override void SetValue(string val)
    {
        transform.rotation = new Quaternion(
            float.Parse(val),
            transform.rotation.y,
            transform.rotation.z,
            transform.rotation.w
            );
    }
}