using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This service locator holds only one instance per object type.
/// </summary>
internal static class UniqueObjectLocator
{
    // List of allowed objects is manually entered for better control and visibility.
    private static readonly HashSet<Type> allowedObjects = new()
    {
        typeof(Scene1_Manager),
        typeof(Scene2_Manager)
        
        // Add more...
    };

    private static readonly Dictionary<Type, object> registeredObjects = new();


    /// <summary>
    /// Register the current instance.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    internal static void RegisterObject<T>(T obj) where T : class
    {
        var type = typeof(T);
        if (allowedObjects.Contains(type)) // Only allowed objects can register themselves.
        {
            registeredObjects[type] = obj;
            Debug.Log($"{obj} registered.");
        }
        else Debug.LogWarning($"{type.Name} is not in allowed obj list.");
    }

    /// <summary>
    /// Removes any object that has null value.
    /// </summary>
    internal static void ValidateObject()
    {
        List<Type> nullObjects = new();

        foreach (Type key in registeredObjects.Keys)
        {
            if (registeredObjects[key] == null) nullObjects.Add(key);
        }

        foreach (Type obj in nullObjects)
        {
            registeredObjects.Remove(obj);
        }
    }

    /// <summary>
    /// Returns the instance of registered object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal static T GetObjectLocation<T>() where T : class
    {
        ValidateObject();

        var type = typeof(T);
        if (registeredObjects.ContainsKey(type))
        {
            return registeredObjects[type] as T;
        }

        return null;
    }

}
