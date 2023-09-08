using UnityEngine;
namespace UMI.JSON
{
    public class UMIJSON
    {
        // Handel Recive message json
        public string message;
        public string status;
        public Data data;
        public CharacterClass[] cDat1 ;
        public CharacterClass[] cDat2  ;
        public SkillClass[] pSkill1  ;
        public SkillClass[] pSkill2;
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