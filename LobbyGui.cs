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
    private void CreatePlayer(int nSlot)
    {
        this.type = Game.typeCharacter;

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
        CreatePlayer(2);
    }
    private void Awake()
    {
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

    }
}
