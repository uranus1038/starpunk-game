using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour
{
    public static Transform findChildObject(Transform parent, string childName)
    {
        Transform childTransform = parent.Find(childName);
        if (childTransform != null)
        {
            // ถ้าค้นเจอ Transform ที่มีชื่อตรงตามที่ต้องการ ก็จะคืนค่า Transform นั้น
            return childTransform;
        }

        // ถ้าไม่เจอที่ Transform ที่ตรงตามที่ต้องการในระดับนี้ จะทำการค้นหาในระดับลูกต่อไป
        foreach (Transform child in parent)
        {
            Transform foundChild = findChildObject(child, childName);
            if (foundChild != null)
            {
                return foundChild;
            }
        }

        // ถ้าไม่เจอเลยในทุกระดับลูก จะคืนค่า null
        return null;
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
}
