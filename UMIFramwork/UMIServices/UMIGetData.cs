using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UMI.HTTP;
namespace UMI.API
{
    public class UMIGetData : MonoBehaviour
    {
        public static UMIGetData star;
        private UMIHTTPClass www = new UMIHTTPClass();
        private void Awake()
        {
            star = this;
        }
        public IEnumerator GetData(string userName,  Action<string> callback)
        {
            WWWForm UMIReq = new WWWForm();
            UMIReq.AddField("userName", userName);
            using (UnityWebRequest reply = UnityWebRequest.Post(www.getURL((int)eHTTP.getDataPlayer), UMIReq))
            {
                yield return reply.SendWebRequest();
                if (reply.result == UnityWebRequest.Result.Success)
                {
                    callback(reply.downloadHandler.text);
                }else
                {
                    callback(reply.error);
                }
               
            }
            
        }

    }
}