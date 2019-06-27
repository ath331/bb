using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomData : MonoBehaviour
{
    [HideInInspector]
    public string roomName = "";
    [HideInInspector]
    public int connectplayer = 0;
    [HideInInspector]
    public int maxPlayers = 20;

    public Text textRoomName;
    public Text textConnectinfo;

    public void DisRoomdate()
    {
        textRoomName.text = roomName;
        textConnectinfo.text = "(" + connectplayer.ToString() + "/" + maxPlayers.ToString() + ")";
    }
}
