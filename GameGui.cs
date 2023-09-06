using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGui : MonoBehaviour
{
    private float display_0;
    private float display_1;
    private bool isGame;
    private bool isTrue;
    private bool isTexture;
    private IconClass Icon;
    private HoverClass hover_0;
    private Texture2D texture_0;
    private Texture2D texture_1;
    private Texture2D texture_2;
    private Texture2D texture_3;
    private Texture2D texture_4;
    private Texture2D texture_5;
    private Texture2D texture_6;
    private Texture2D texture_7;
    private Texture2D texture_8;
    private Texture2D texture_9;
    private Texture2D texture_10;

    private GUIStyle style_0;
    private GUIStyle style_1;
    private GUIStyle style_2;
    private GUIStyle style_3;
    private GUIStyle style_4;
    private GUIStyle style_5;
    private GUIStyle style_6;
    private GUIStyle style_7;
    private void Init()
    {
        this.hover_0 = new HoverClass();
        this.Icon = new IconClass();
        this.Icon.image = (Texture2D)Resources.Load("GUI/Icon/null", typeof(Texture2D));
        this.isGame = true;
        this.InitChracterOption();
        this.InitStatusbar();
        this.InitWorldMap();
        this.InitSkillBar();
        this.InitNetworkBar();
        this.InitInventory();
    }
    private void InitChracterOption()
    {
        this.texture_0 = (Texture2D)Resources.Load("GUI/Game/CharacterBg", typeof(Texture2D));
        this.texture_1 = (Texture2D)Resources.Load("GUI/Game/useBar", typeof(Texture2D));
        this.texture_2 = (Texture2D)Resources.Load("GUI/Game/HPMPSPMX", typeof(Texture2D));
        this.texture_3 = (Texture2D)Resources.Load("GUI/Game/HPMPSPTX", typeof(Texture2D));
        this.texture_4 = (Texture2D)Resources.Load("GUI/Characters/Wolf", typeof(Texture2D));
        this.style_0 = new GUIStyle(); 
        this.style_0.hover.background = (Texture2D)Resources.Load("GUI/Game/bagIcon_h", typeof(Texture2D));  
        this.style_1 = new GUIStyle(); 
        this.style_1.hover.background = (Texture2D)Resources.Load("GUI/Game/statusIcon_h", typeof(Texture2D));
        this.style_2 = new GUIStyle();
        this.style_2.hover.background = (Texture2D)Resources.Load("GUI/Game/skillIcon_h", typeof(Texture2D));
        this.style_3 = new GUIStyle();
        this.style_3.hover.background = (Texture2D)Resources.Load("GUI/Game/networkIcon_h", typeof(Texture2D));
    }
    private void InitSkillBar()
    {
        this.texture_7 = (Texture2D)Resources.Load("GUI/SkillCharacter/Wolf/Skill_Basic_Wolf", typeof(Texture2D));

        this.style_4 = new GUIStyle();
        this.style_4.hover.background = (Texture2D)Resources.Load("GUI/Game/AButton_h", typeof(Texture2D));

        this.style_5 = new GUIStyle();
        this.style_5.hover.background = (Texture2D)Resources.Load("GUI/Game/BButton_h", typeof(Texture2D));

        this.style_6 = new GUIStyle();
        this.style_6.hover.background = (Texture2D)Resources.Load("GUI/Game/BasicButton_h", typeof(Texture2D));

    }
    private void InitStatusbar()
    {
        this.texture_6 = (Texture2D)Resources.Load("GUI/Game/StatusBar", typeof(Texture2D));
    }
    private void InitWorldMap()
    {
        this.texture_5 = (Texture2D)Resources.Load("GUI/Game/MiniMap", typeof(Texture2D));
    }
    private void InitNetworkBar()
    {
        this.texture_8 = (Texture2D)Resources.Load("GUI/Game/NetworkBar", typeof(Texture2D));
    }
    private void InitInventory()
    {
        this.texture_9 = (Texture2D)Resources.Load("GUI/Game/InventoryBar", typeof(Texture2D));
        this.texture_10 = (Texture2D)Resources.Load("GUI/Game/UranusBg01", typeof(Texture2D));
        this.style_7 = new GUIStyle();
        this.style_7.hover.background = (Texture2D)Resources.Load("GUI/Game/Trash_h", typeof(Texture2D));
    }
    void Start()
    {

    }
    private void Awake()
    {
        this.Init();
    }
    private void Update()
    {
       
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        this.display_1 = (float)Screen.height / 1024f;
        if(this.isGame)
        {
            this.RenderNetWorkBar();
            this.RenderChracterUse();
            this.RenderStatusBar();
            this.RenderSkillBar();
            this.RenderInventory();
        }
    }
    private void RenderChracterUse()
    {
        // # character bar
        GUI.DrawTexture(new Rect(0f, this.display_1 + 799, 445, 225f), this.texture_0);
        // # Item bar
        GUI.DrawTexture(new Rect(1f * this.display_0 - 1167f, this.display_1 + 844f, 1168f, 180f), this.texture_1);
        
        this.GUIControl(); 
        // # HPMPSP bar
        GUI.DrawTexture(new Rect(155f, this.display_1 + 928f, 230f, 90f), this.texture_2);
        // # Character
        GUI.DrawTexture(new Rect(0f, this.display_1 + 680f, 300f, 380f), this.texture_4);
        // #HPMPSPTX text
        GUI.DrawTexture(new Rect(155f, this.display_1 + 928, 230f, 90f), this.texture_3);
        // # MiniMap
        GUI.DrawTexture(new Rect(0, 0, 360f, 250f), this.texture_5);
    }
    private void RenderInventory()
    {
        if(Game.eInventory == eInventory.Active)
        {
            GUI.DrawTexture(new Rect(1f * this.display_0 - 505f, this.display_1 + 482f, 450f, 410f), this.texture_9);
            GUI.DrawTexture(new Rect(1f * this.display_0 - 445f, this.display_1 + 601f, 349f, 193f), this.texture_10);
            if(GUI.Button(new Rect(1f * this.display_0 - 110f, this.display_1 + 744f, 33f, 38f), string.Empty,this.style_7))
            {

            }
        }
    }   
    private void RenderStatusBar()
    {
        if(Game.eMenu == eMenuOptionState.Status)
        {
            GUI.DrawTexture(new Rect(1f * this.display_0 - 505f, this.display_1 + 18f, 450f, 450f), this.texture_6);
        }
    }
    private void RenderSkillBar()
    {
        if (Game.eMenu == eMenuOptionState.Skill)
        {
            GUI.DrawTexture(new Rect(1f * this.display_0 - 505f, this.display_1 + 78f, 450f, 820f), this.texture_7);
            if (GUI.Button(new Rect(1f * this.display_0 - 357f, this.display_1 + 121f, 81f, 35f), string.Empty, this.style_5))
            {

            }
            if (GUI.Button(new Rect(1f * this.display_0 - 413f, this.display_1 + 121f, 81f, 35f), string.Empty, this.style_4))
            {
                UMI.UMISystem.Log("Button 1 Clicked");
            }
            if (GUI.Button(new Rect(1f * this.display_0 - 480f, this.display_1 + 121f, 81f, 35f),string.Empty ,this.style_6))
            {
                UMI.UMISystem.Log("Button 2 Clicked");
            }
        }
    }
    private void RenderNetWorkBar()
    {
        if (Game.eMenu == eMenuOptionState.Network)
        {
            GUI.DrawTexture(new Rect(1f * this.display_0 - 419f, this.display_1 + 420f, 420f, 605f), this.texture_8);
        }
    }
    private void GUIControl()
    {
        // # h Inventory
        if (GUI.Button(new Rect(1f * this.display_0 - 144f, this.display_1 + 905f, 60f, 50f), string.Empty, this.style_0))
        {
            if (Game.eInventory != eInventory.Active)
            {
                Game.eInventory = eInventory.Active;
                Game.eMenu = eMenuOptionState.Status;
            }
            else
            {
                Game.eInventory = eInventory.none;
            }
        }
        // # h status
        if (GUI.Button(new Rect(1f * this.display_0 - 67f, this.display_1 + 905f, 60f, 50f), string.Empty, this.style_1))
        {
            if (Game.eMenu != eMenuOptionState.Status)
            {
                Game.eMenu = eMenuOptionState.Status;
            }
            else
            {
                Game.eMenu = eMenuOptionState.Game;
            }
        }
        // # h skill
        if (GUI.Button(new Rect(1f * this.display_0 - 144f, this.display_1 + 962f, 60f, 50f), string.Empty, this.style_2))
        {
            if (Game.eMenu != eMenuOptionState.Skill)
            {
                Game.eMenu = eMenuOptionState.Skill;
                Game.eInventory = eInventory.none;
            }
            else
            {
                Game.eMenu = eMenuOptionState.Game;
            }
        }
        // # h network
        if (GUI.Button(new Rect(1f * this.display_0 - 67f, this.display_1 + 962f, 60f, 50f), string.Empty, this.style_3))
        {
            if (Game.eMenu != eMenuOptionState.Network)
            {
                Game.eMenu = eMenuOptionState.Network;
                Game.eInventory = eInventory.none;
            }
            else
            {
                Game.eMenu = eMenuOptionState.Game;
            }
        }
    }
    private void RenderTest()
    {
        //Rect keyCodeNumber = new Rect(1f * this.display_0 - 1167f, this.display_1 + 844f, 1168f, 180f);
        //GUI.BeginGroup(keyCodeNumber);
        //GUILayout.BeginHorizontal();
        //GUILayout.BeginArea(new Rect(0, 0, 100, keyCodeNumber.height));
        //GUILayout.Button("Button 1");
        //GUILayout.EndArea();
        //GUILayout.EndHorizontal();
        //GUI.EndGroup();
    }
    
}
