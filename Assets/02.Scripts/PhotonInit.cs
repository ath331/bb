using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonInit : MonoBehaviour
{
    public string version = "v1.0";
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(version);
    }

    void OnJoinedLobby()
    {
        Debug.Log("Entered Lobby !");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("No rroms !");
        PhotonNetwork.CreateRoom("MyRoom");
    }

    void OnJoinedRoom()
    {
        Debug.Log("Enter Room !");
        CreateTank();
    }

    void CreateTank()
    {
        float pos = Random.Range(-100.0f, 100.0f);
        PhotonNetwork.Instantiate("Tank", new Vector3(pos, 20.0f, pos), Quaternion.identity, 0);
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
