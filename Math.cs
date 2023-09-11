using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
public class Math : MonoBehaviour
{
    public static float div(int i, float n)
    {
        return (i == 1f) ? Mathf.FloorToInt(n) : Mathf.FloorToInt(n * i);
    }
    public static Transform findChildObject(Transform parent, string childName)
    { 
        Transform childTransform = parent.Find(childName);
        if (childTransform != null)
        {
            return childTransform;
        }

        foreach (Transform child in parent)
        {
            Transform foundChild = findChildObject(child, childName);
            if (foundChild != null)
            {
                return foundChild;
            }
        }
        return null;
    }
    public static Color HexToColor(string hex)
    {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        else
        {
            Debug.LogError("Invalid hex color code: " + hex);
            return Color.black;
        }
    }
    public static void DestroyObject(int max ,GameObject[] gameObject)
    {
        for(int i =1;i<=max; i++)
        {
            if(gameObject[i] != null)
            {
                UnityEngine.GameObject.Destroy(gameObject[i]);
            }
        }
    }

    public static bool[] BoolAllArray(bool[] nAarry)
    {
        return nAarry.Select(isCheck => false).ToArray();
    }
}
