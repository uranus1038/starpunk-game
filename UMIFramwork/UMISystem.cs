using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMI
{
    public class UMISystem : MonoBehaviour
    {
        public static void Log(string msg)
        {
            print("UMI::"+msg);
        }
        public static void Log(int msg)
        {
            print("UMI::" + msg);
        }
    }

}
