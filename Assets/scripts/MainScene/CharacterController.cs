using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CharacterController : MonoBehaviour {

public PhotonView myPV;
public PhotonTransformView myPTV;
private Camera mainCam;

private TextMeshProUGUI cardNameText;

void Start () {
    if (myPV.IsMine)
    {
        cardNameText = this.GetComponent<TextMeshProUGUI>();
        cardNameText.text = PhotonNetwork.LocalPlayer.NickName;
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    }
}

void Update () {
    if (!myPV.IsMine)
    {
        return;
    }
    // moveControl(); 
    // RotationControl(); 

    // controller.Move(moveDirection * Time.deltaTime);
    //for smooth syhchronization
    // Vector3 velocity = controller.velocity;
    // myPTV.SetSynchronizedValues(velocity, 0);   
    }

}