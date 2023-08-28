using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyGui : MonoBehaviour
{
    internal protected float delay_0;
    internal protected float display_0;
    private string type_0;
    private string type_1;
    private string custume_0;
    private string custume_1;
    private GameObject[] player;
    private eLobby eLobby;
    private eLobbyMenu eLobbyMenu;
    private eCreateChar eCreateChar;
    private LoadingGui loading;
    private Vector3[] spawnPosition;
    private Quaternion[] spawnRotation;
    private float[] buttonPositionX; 
    private void CreatePlayer()
    {
        for (int i = 1; i <= 2; i++)
        {
            CharacterDataClass CharacterDataClass = CharacterData.getCdat(i);
            if (CharacterDataClass.getUID() != -1)
            {
                this.type_0 = CharacterDataClass.addType();
                this.custume_0 = "Leo";
                this.player[i] = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load($"GameAssets/Characters/{this.type_0}/Custume/{this.custume_0}", typeof(GameObject)), this.spawnPosition[i], this.spawnRotation[i]);
                this.player[i].name = "character" + i;
            }
            else
            {
                global::UMI.UMISystem.LogList("LobbyGui", "35", "chracter init fails because not data player " + i);
            }
        }
    }
    private void Init()
    {
        this.player = new GameObject[5];
        this.spawnPosition = new Vector3[]
        {
          Vector3.zero ,
          new Vector3(0f, 4.2f, 0f) ,
          new Vector3(-5.5f, 4.2f, 1.5f)
        };
        this.spawnRotation = new Quaternion[]
        {
          Quaternion.identity,
          Quaternion.Euler(0,180,0),
          Quaternion.Euler(0,150,0)
        };
        this.buttonPositionX = new float[] 
        {
            0f,
            0f,
            500f,
           -500f
        };

    }
    void Start()
    {
        this.delay_0 = Time.time;
    }
    private void Awake()
    {
        this.Init();
        this.eLobby = eLobby.lobby;
        this.eLobbyMenu = eLobbyMenu.Init;
        this.eCreateChar = eCreateChar.start;
        this.loading = (LoadingGui)this.GetComponent(typeof(LoadingGui));
    }
    void Update()
    {

    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if (this.eLobby != eLobby.connected)
        {
            if (this.eLobby == eLobby.lobby)
            {
                this.RenderLobbyMenu();
                return;
            }
            if (this.eLobby == eLobby.createChar)
            {
                this.RenderCreateChar();
                return;
            }
        }

    }
    private void RenderLobbyMenu()
    {
        if (this.eLobbyMenu == eLobbyMenu.Init)
        {
            this.CreatePlayer();
            this.eLobbyMenu = eLobbyMenu.lobby;
        }
        if (this.eLobbyMenu == eLobbyMenu.lobby)
        {
            this.RenderSelectChar();
        }
    }
    private void RenderCreateChar()
    {
        if(this.eCreateChar == eCreateChar.start)
        {
            this.RenderSelectCreateChar();
        }
    }
    private void RenderSelectChar()
    {
        for(int i=1;i<=2;++i )
        {
            CharacterDataClass CharacterDataClass = CharacterData.getCdat(i);
            if(CharacterDataClass.getUID() == -1f)
            {
                    if (GUI.Button(new Rect(0.5f * this.display_0 - buttonPositionX[i], 863f, 126.5f, 62f), "slot" + i))
                    {
                        this.NextCreateChar();
                    }
            }
        }   
    }
    private void RenderSelectCreateChar()
    {
       
        if (GUI.Button(new Rect(0.5f * this.display_0 - 0f, 863f, 126.5f, 62f), "back"))
        {
            this.eLobby = eLobby.lobby;
            this.eLobbyMenu = eLobbyMenu.Init;
        }
        if (GUI.Button(new Rect(0.5f * this.display_0 - 500f, 863f, 126.5f, 62f), "create"))
        {
           
        } if (GUI.Button(new Rect(0.5f * this.display_0 + 500f, 863f, 126.5f, 62f), "select"))
        {
            this.player[1] = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load($"GameAssets/Characters/Leo/Custume/Leo", typeof(GameObject)), this.spawnPosition[1], this.spawnRotation[1]);
        }
    }
    private void NextCreateChar()
    {
        global::Math.DestroyObject(2, this.player);
        this.eLobby = eLobby.createChar;
    }
}
