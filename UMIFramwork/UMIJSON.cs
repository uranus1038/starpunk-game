using UnityEngine;
namespace UMI.JSON
{
    public class UMIJSON
    {
        // Handel Recive message json
        public string message;
        public string status;
        public Data data = new();
        [System.Serializable]
        public class Data
        {
            public string userName;
            public string gender;
        }
        public UMIJSON UMIRespon(string data)
        {
            UMIJSON JSON = JsonUtility.FromJson<UMIJSON>(data);
            return JSON;
        }
    }
}