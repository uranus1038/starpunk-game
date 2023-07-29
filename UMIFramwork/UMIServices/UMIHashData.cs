using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.JSON; 
namespace UMI.Data
{
    public class UMIHashData : MonoBehaviour
    {
        internal protected static UMIJSON JSON = new UMIJSON();
        public static UMIJSON req;
        public static Hashtable hdac = new Hashtable();

        public static void playerSetData(string data)
        {
            req = JSON.UMIRespon(data);
            switch (req.status)
            {
                case "200":
                    try
                    {
                        hdac.Add(01, req.data.userName);
                        hdac.Add(01, req.data.gender);
                        UMISystem.Log(req.data.userName);
                        UMISystem.Log(req.data.gender);
                    }
                    catch
                    {
                    }
                    break;
                default:
                    break;
            }
        }
        public static void HTTPStatus(string status)
        {
            req = JSON.UMIRespon(status);
        }
    }
}


