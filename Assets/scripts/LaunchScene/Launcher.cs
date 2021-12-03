using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
 
public class Launcher : MonoBehaviourPunCallbacks
{

    void Start(){
        Button play_button = this.transform.Find("PlayButton").gameObject.GetComponent<Button>();
        play_button.onClick.AddListener(Connect); 
    }

    public void Connect(){
        if (!PhotonNetwork.IsConnected) { 
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("connected to Photon");
            SceneManager.LoadScene("Lobby");
        }
    }

    void OnGUI()
    {
        //output login status on GUI
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }


    // //Auto-JoinLobbyにチェックを入れているとPhotonに接続後OnJoinLobby()が呼ばれる。
    // public override void OnJoinedLobby()        
    // {
    //     Debug.Log("entered the lobby");
    //     PhotonNetwork.JoinRandomRoom(); 
    // }
 
    // public override void OnConnectedToMaster() {
    //     PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    // }
 
    // //Called when succeeded joining the room
    // public override void OnJoinedRoom()
    // {
    //     Debug.Log("joined the room");
    //     PhotonNetwork.LoadLevel("Stage");
    // }
 
}
