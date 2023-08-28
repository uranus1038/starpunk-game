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
            // ��Ҥ��� Transform ����ժ��͵ç�������ͧ��� ��Ф׹��� Transform ���
            return childTransform;
        }

        // �������ͷ�� Transform ���ç�������ͧ�����дѺ��� �зӡ�ä�����дѺ�١����
        foreach (Transform child in parent)
        {
            Transform foundChild = findChildObject(child, childName);
            if (foundChild != null)
            {
                return foundChild;
            }
        }

        // �����������㹷ء�дѺ�١ �Ф׹��� null
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
