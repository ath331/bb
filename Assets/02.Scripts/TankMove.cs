using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class TankMove : MonoBehaviour
{
    private float moveSpeed = 20.0f;
    private float rotSpeed = 50.0f;

    private Rigidbody rbody;
    private Transform tr;

    private float h, v;

    private PhotonView pv = null;
    public Transform camPivot;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        

        pv = GetComponent<PhotonView>();
        if(pv.isMine)
        {
            Camera.main.GetComponent<SmoothFollow>().target = camPivot;
            rbody.centerOfMass = new Vector3(0.0f, -0.5f, 0.0f);
        }
        else
        {
            rbody.isKinematic = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!pv.isMine) return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        tr.Rotate(Vector3.up * rotSpeed * h * Time.deltaTime);
        tr.Translate(Vector3.forward * v * moveSpeed * Time.deltaTime);
    }
}
