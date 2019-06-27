using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PhotonInit : MonoBehaviour
{
    public string version = "v1.0";

    public InputField userId;

    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(version);
    }

    void OnJoinedLobby()
    {
        Debug.Log("Entered Lobby !");
        userId.text = GetUserId();
        //PhotonNetwork.JoinRandomRoom();
    }

    string GetUserId()
    {
        string userId = PlayerPrefs.GetString("USER_ID");
        if(string.IsNullOrEmpty(userId))
        {
            userId = "USER_<" + Random.Range(0, 999).ToString("000");
        }
        return userId;
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("No rroms !");
        PhotonNetwork.CreateRoom("MyRoom");
    }

    void OnJoinedRoom()
    {
        Debug.Log("Enter Room !");
        //CreateTank();
        StartCoroutine(this.LoadBattleField());
    }

    IEnumerator LoadBattleField()
    {
        PhotonNetwork.isMessageQueueRunning = false;
        AsyncOperation ao = SceneManager.LoadSceneAsync("scBattleField");
        yield return ao;
    }

    public void OnClickJoinRandomRoom()
    {
        PhotonNetwork.player.NickName = userId.text;
        PlayerPrefs.SetString("USER_ID", userId.text);

        PhotonNetwork.JoinRandomRoom();
    }

   /* void CreateTank()
    {
        float pos = Random.Range(-100.0f, 100.0f);
        PhotonNetwork.Instantiate("Tank", new Vector3(pos, 20.0f, pos), Quaternion.identity, 0);
    }*/

    // Update is called once per frame
    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
