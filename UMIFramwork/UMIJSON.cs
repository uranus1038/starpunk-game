using UnityEngine;
namespace UMI.JSON
{
    public class UMIJSON
    {
        // Handel Recive message json
        public string message;
        public string status;
        public Data data = new();
        public CharacterClass cDac1 = new();
        public CharacterClass cDac2 = new();
        [System.Serializable]
        public class Data
        {
            public string userName;
            public int UID;
        }
        public UMIJSON UMIRespon(string data)
        {
            UMIJSON JSON = JsonUtility.FromJson<UMIJSON>(data);
            return JSON;
        }
    }
}