using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyGui : MonoBehaviour
{
    internal protected float delay_0;
    internal protected float display_0;
    private string type;
    private string type1;
    private GameObject player_0;
    private GameObject player_1;
    private eLobby eLobby;
    private LoadingGui loading; 
    private void CreatePlayer()
    {
        this.eLobby = eLobby.lobby; 
        this.type = Game.typeCharacter;
        CharacterData.Init();
        this.player_0 = Instantiate((GameObject)Resources.Load(this.type, typeof(GameObject)), new Vector3(0f, 4.2f, -0.4f), Quaternion.Euler(1f, 180f, 1f));
        this.player_0.name = "character1";
        this.player_1 = Instantiate((GameObject)Resources.Load(this.type1, typeof(GameObject)), new Vector3(-5.5f, 4.2f, 1.5f), Quaternion.Euler(1f, 150f, 1f));
        this.player_1.name = "character2";

    }
    private void Init()
    {

    }
    void Start()
    {
       

    }
    private void Awake()
    {
        this.eLobby = eLobby.Init;
        this.loading = (LoadingGui)this.GetComponent(typeof(LoadingGui));
        Game.typeCharacter = $"GameAssets/Characters/Leo/Custume/Leo";
        this.type1 = $"GameAssets/Characters/Aries/Custume/Aries";
    }
    void Update()
    {

    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if(this.eLobby == eLobby.Init)
        {
            this.loading.fadeIn(1f);
            this.CreatePlayer();
        }
    }

}
