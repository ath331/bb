using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    private GameObject cannon = null;
    public Transform firePos;

    private PhotonView pv = null;

    // Start is called before the first frame update
    void Awake()
    {
        cannon = (GameObject)Resources.Load("Cannon");
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.isMine && Input.GetMouseButtonDown(0))
        {
            Fire();
            pv.RPC("Fire", PhotonTargets.Others, null);
        }
    }
    [PunRPC]
    void Fire()
    {
        Instantiate(cannon, firePos.position, firePos.rotation);
    }
    
}