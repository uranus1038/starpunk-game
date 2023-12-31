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
            UMISystem.LogList("UMIHashData","50",data);
            req = JSON.UMIRespon(Game.request);
            if(req.cDat1.Length == 0 && req.cDat2.Length == 0)
            {
                CharacterData.Init();
            }
            {
                if (req.cDat1.Length > 0)
                {
                    CharacterClass pDat = req.cDat1[0];
                    SkillClass pSk = req.pSkill1[0];
                    CharacterData.cDat1.setCdat(pDat, pSk);
                }
                else
                {
                    CharacterData.cDat1.Init(1);
                    UMISystem.LogList("UMIHashData", "63", "slot 1 none data");
                }
                if (req.cDat2.Length > 0)
                {
                    CharacterClass pDat = req.cDat2[0];
                    SkillClass pSk = req.pSkill2[0];
                    CharacterData.cDat2.setCdat(pDat , pSk);
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



