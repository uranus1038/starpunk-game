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
        private void Start()
        {
            star = this;
            StartCoroutine(GetLogin("you"));
        }
        public IEnumerator GetLogin(string name)
        {
            WWWForm UMIReq = new WWWForm();
            UMIReq.AddField("name", name);
            using (UnityWebRequest reply = UnityWebRequest.Post(www.getURL("getLogin"), UMIReq))
            {
                yield return reply.SendWebRequest();
                if (reply.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log(reply.downloadHandler.text);
                }
            }

        }

    }
}