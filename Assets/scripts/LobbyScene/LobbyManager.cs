using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Collections.Generic;
 
namespace Com.MyCompany.MyGameMonoBehaviourPunCallbacks
{
    public class LobbyManager :MonoBehaviourPunCallbacks 
    {
        public  GameObject RoomParent;//content object of ScrolView
        private GameObject RoomElementPrefab;
        public Text InfoText;

        void Awake()
        {
            //clients in the scene will load the same scene as the master.
            PhotonNetwork.AutomaticallySyncScene = true;
        }
 
        void Start()
        {

        }


         public static void DestroyChildObject(Transform parent_trans)
        {
            for (int i = 0; i < parent_trans.childCount; ++i)
            {
                GameObject.Destroy(parent_trans.GetChild(i).gameObject);
            }
        }

        //GetRoomList is updated regularly
        public override void OnRoomListUpdate(List<RoomInfo> roomInfo)
        {
            DestroyChildObject(RoomParent.transform);  
            if (roomInfo == null || roomInfo.Count == 0) return;
 
            for (int i = 0; i < roomInfo.Count; i++)
            {
                Debug.Log(roomInfo[i].Name + " : " + roomInfo[i].Name + "–" + roomInfo[i].PlayerCount + " / " + roomInfo[i].MaxPlayers /*+ roomInfo[i].CustomProperties["roomCreator"].ToString()*/);
                RoomElementPrefab = Resources.Load("player",  typeof(GameObject)) as GameObject;
                GameObject RoomElement = GameObject.Instantiate(RoomElementPrefab);
                RoomElement.transform.SetParent(RoomParent.transform);
                RoomElement.GetComponent<RoomElement>().SetRoomInfo(roomInfo[i].Name, roomInfo[i].PlayerCount, roomInfo[i].MaxPlayers, roomInfo[i].CustomProperties["RoomCreator"].ToString());
            }
        }
        
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            InfoText.text = "failed to create a new room";
        }
 
        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            InfoText.text = "failed to join a room";
        }
 
        public override void OnJoinedRoom()
        {
            // LocalVariables.VariableReset();
        }

        public override void OnCreatedRoom()
        {
            PhotonNetwork.LoadLevel("Stage");
        }
    }
}