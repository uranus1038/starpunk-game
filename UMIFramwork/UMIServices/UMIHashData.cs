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
                                hDac.Add(1, req.data.userName);
                                UMISystem.Log(req.data.userName);
                            }
                            catch
                            {
                            }
                            break;
                    }
                }

            }

        }
        public static void playerLoadData(string data )
        {
            CharacterData.Init();
            UMISystem.Log(data);
            req = JSON.UMIRespon(data);
            if(req.cDat1.Length == 0 && req.cDat2.Length == 0)
            {
                CharacterData.Init();
            }
            {
                if (req.cDat1.Length > 0)
                {
                    CharacterClass pDat1 = req.cDat1[0];
                    CharacterData.cDat1.setCdat(pDat1);
                }
                else
                {
                    CharacterData.cDat1.Init(1);
                    UMISystem.LogList("UMIHashData", "63", "slot 1 none data");
                }
                if (req.cDat2.Length > 0)
                {
                    CharacterClass pDat2 = req.cDat2[0];
                    CharacterData.cDat2.setCdat(pDat2);
                }
                else
                {
                    CharacterData.cDat2.Init(2);
                    UMISystem.LogList("UMIHashData", "63", "slot 2 none data");
                }
                Game.isLoadDac = true;
            }
        }

    }
}



