using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMI
{
    public class UMISystem : MonoBehaviour
    {
        internal protected float display_0;
        internal protected float delay_0;
        private Texture texture_0; // bg_black
        private void Awake()
        {
            this.Init();
          
        }
        public static void Log(string msg)
        {
            print("UMI::"+msg);
        }
        public static void Log(int msg)
        {
            print("UMI::" + msg);
        }
        public static void Log(bool msg)
        {
            print("UMI::" + msg);
        }
        private void Init()
        {
            this.texture_0 = this.texture_0 = (Texture)Resources.Load("GUI/Login/white", typeof(Texture));
        }
        private void Update()
        {

           if(Input.GetKey(KeyCode.F8)&& Input.GetKey(KeyCode.LeftControl) && !Game.isConsole)
            {
                Game.isConsole = true;
                this.delay_0 = Time.time;
                Log("true");
            }
        }

        private void OnGUI()
        {
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
            GUI.depth = 2;
            this.display_0 = (float)(1024 * Screen.width / Screen.height);
            if(Game.isConsole)
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, Mathf.Lerp(-1080f,0f,(Time.time - this.delay_0)*2f), 1980f, 1080f), this.texture_0);
            }
                
        }
    }

}
