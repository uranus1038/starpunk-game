using UnityEngine;
using System.Net;
namespace UMI.Network.Client
{
    public class UMIClientHandle : MonoBehaviour
    {
        public static void OnJoinServer(UMIPacket packet)
        {
            string Msg = packet.ReadString();
            int CID = packet.ReadInt();
            UMISystem.Log($"{Msg}");
            UMIClientManager.star.CID = CID;
            UMIClientSend.playerConnect(CID);
            try
            {
                UMIClientManager.star.UDP.Connect(((IPEndPoint)UMIClientManager.star.TCP.socket.Client.LocalEndPoint).Port);
            }
            catch
            {
                UMISystem.Log("LocalEndPoint NULL");
            }
        }
    }
}