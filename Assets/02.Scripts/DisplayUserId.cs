using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayUserId : MonoBehaviour
{
    public Text userId;
    private PhotonView pv = null;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        userId.text = pv.owner.NickName;
    }
}
