using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public Text txtConnect;
    public Text txtLogMsg;
    private PhotonView pv;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();

        CreateTank();
        PhotonNetwork.isMessageQueueRunning = true;

        GetConnectPlayerCount();
    }
    private void Start()
    {
        string msg = "\n<color=#00ff00>[" + PhotonNetwork.player.NickName + "] Connectd</color>";
        pv.RPC("LogMsg", PhotonTargets.AllBuffered, msg);
    }

    void CreateTank()
    {
        float pos = Random.Range(-100.0f, 100.0f);
        PhotonNetwork.Instantiate("Tank", new Vector3(pos, 20.0f, pos), Quaternion.identity, 0);
    }

    void GetConnectPlayerCount()
    {
        Room currRoom = PhotonNetwork.room;

        txtConnect.text = currRoom.PlayerCount.ToString() + "/" + currRoom.MaxPlayers.ToString();
    }

    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
       // Debug.Log(newPlayer.ToStringFull());
        GetConnectPlayerCount();
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer outPlayer)
    {
        GetConnectPlayerCount();
    }
    [PunRPC]
    void LogMsg(string msg)
    {
        txtLogMsg.text = txtLogMsg.text + msg;
    }

    public void OnClickExitRoom()
    {
        string msg = "\n<color=#ff0000>[" + PhotonNetwork.player.NickName + "] DisConnected</color>";
        pv.RPC("LogMsg", PhotonTargets.AllBuffered, msg);
        PhotonNetwork.LeaveRoom();
    }
    void OnLeftRoom()
    {
        SceneManager.LoadScene("scLobby");
    }
}
