
using UnityEngine;
namespace UMI.Network.Client
{
    public class UMIClientSend : MonoBehaviour
    {
        #region UMIFUNC SEND TCP & UDP
        private static void sendTCPData(UMIPacket packet)
        {
            packet.WriteLength();
            UMIClientManager.star.TCP.SendData(packet);
        }
        private static void sendUDPData(UMIPacket packet)
        {
            packet.WriteLength();
            // UMIClientManager.star.UDP.SendData(packet);
        }
        private static void sendUDPData(int UID, UMIPacket packet)
        {
            packet.WriteLength();
            UMIClientManager.star.UDP.SendData(packet);
        }
        #endregion
        public static void playerConnect(int CID)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqConnectServer))
            {
                UMISystem.Log("Send data player");
                packet.Write(CID);
                sendTCPData(packet);
            }
        }
    }
}