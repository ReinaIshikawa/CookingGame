using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
 
public class RoomElement : MonoBehaviour {
    private Text RoomName;
    private Text PlayerNumber; 
    private Text RoomCreator; 
    private Button EnterButton;

    private string roomname;

    void start(){
        RoomName = this.gameObject.transform.Find("RoomInfoPanel/RoomName").gameObject.GetComponent<Text>();
        PlayerNumber = this.gameObject.transform.Find("RoomInfoPanel/PlayerNumber").gameObject.GetComponent<Text>();
        RoomCreator = this.gameObject.transform.Find("RoomInfoPanel/RoomCreator").gameObject.GetComponent<Text>();
        EnterButton = this.gameObject.transform.Find("EnterButton").gameObject.GetComponent<Button>();
        EnterButton.onClick.AddListener(OnJoinRoomButton);
    }

    public void SetRoomInfo(string _RoomName,int _PlayerNumber,int _MaxPlayer,string _RoomCreator)
    {
        roomname = _RoomName;
        RoomName.text ="Room name："+_RoomName;
        PlayerNumber.text ="# players：" +_PlayerNumber+"/"+_MaxPlayer;
        RoomCreator.text = "creator："+_RoomCreator;
    }
 
    public void OnJoinRoomButton()
    {
        PhotonNetwork.JoinRoom(roomname);
    }
}
