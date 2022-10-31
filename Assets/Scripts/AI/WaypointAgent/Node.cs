using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static T[] FindNodesOfType<T>() where T : Node
    {
        return FindObjectsOfType<T>();
    }

    public static T GetRandomNode<T>() where T : Node
    {
        var nodes = FindNodesOfType<T>();
        return nodes.Length > 0 ? nodes[Random.Range(0, nodes.Length)] : null;
    }

    public static T GetRandomNode<T>(List<T> nodes) where T : Node
    {
        return nodes.Count > 0 ? nodes[Random.Range(0, nodes.Count)] : null;
    }
}
