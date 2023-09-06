using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
public class Math : MonoBehaviour
{
    public static int div(float integer, float divider)
    {
        integer = Mathf.Floor(integer);
        divider = Mathf.Floor(divider);
        return Mathf.FloorToInt(integer / divider);
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
