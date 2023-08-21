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
        public static Hashtable hDac = new Hashtable();

        public static void playerSetData(string data)
        {
            if (data == "HTTP/1.1 429 Too Many Requests")
            {
                req = JSON.UMIRespon("{\"status\":\"429\"}");
            }
            else
            {
                if (data == "Cannot connect to destination host")
                {

                    req = JSON.UMIRespon("{\"status\":\"500\"}");
                }
                else
                {
                    req = JSON.UMIRespon(data);
                    switch (req.status)
                    {
                        case "200":
                            try
                            {
                                hDac.Add(01, req.data.userName);
                                hDac.Add(01, req.data.gender);
                                UMISystem.Log(req.data.userName);
                                UMISystem.Log(req.data.gender);
                            }
                            catch
                            {
                            }
                            break;

                    }
                }

            }

        }

    }
}



