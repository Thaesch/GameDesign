﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public static class RBExtensions
{

    public static T FindComponentInObjectOrParent<T>(this GameObject gobj)
    {
        Transform t = gobj.transform;
        while (t != null)
        {
            var component = t.GetComponent<T>();
            if (component != null)
            {
                return component;
            }
            t = t.parent?.transform;
        }
        throw new Exception(gobj.GetType() + " has no parent with component " + typeof(T));
    }

    /// <summary>
    /// Returns the connection id which is unique and between <see cref="Int16.MinValue"/> and <see cref="Int16.MaxValue"/>.
    /// </summary>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static short GetPlayerId(this NetworkConnection conn)
    {
        return (short)conn.connectionId;
    }

    public static void SetLayerRecursively(this GameObject obj, int layer)
    {
        if (obj == null) return;

        obj.layer = layer;

        foreach(Transform child in obj.transform)
        {
            if (child == null) continue;
            child.gameObject.SetLayerRecursively(layer);
        }
    }

    public static void SetTagRecursively(this GameObject obj, string tag)
    {
        if (obj == null) return;
        obj.tag = tag;

        foreach(Transform child in obj.transform)
        {
            if (child == null) continue;
            child.gameObject.SetTagRecursively(tag);
        }
    }
}
