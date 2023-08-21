using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UMI.HTTP; 
namespace UMI.API
{
    public class UMIGetLogin : MonoBehaviour
    {
        public static UMIGetLogin star;
        private UMIHTTPClass www = new UMIHTTPClass();  
        private void Awake()
        {
            star = this; 
        }
        public IEnumerator GetLogin(string email, string QUk8sYq_x , Action<string> callback)
        {
            WWWForm UMIReq = new WWWForm();
            UMIReq.AddField("email", email);
            UMIReq.AddField("QUk8sYq_x", QUk8sYq_x);
            using (UnityWebRequest reply = UnityWebRequest.Post(www.getURL("getLogin"), UMIReq))
            {
                yield return reply.SendWebRequest();
                if (reply.result == UnityWebRequest.Result.Success)
                {
                    callback(reply.downloadHandler.text);
                }
                else
                {
                    callback(reply.error);
                }
            }

        }

    }
}