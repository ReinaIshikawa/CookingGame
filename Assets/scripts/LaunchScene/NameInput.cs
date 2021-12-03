using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
 
public class NameInput :  MonoBehaviour
{
    static string playerNamePrefKey = "PlayerName";

    void Start()
    {
        string defaultName = "";   
        InputField _inputField = this.GetComponent<InputField>();
 
        //load name of previous game
        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }
        // _inputField.onValueChanged.AddListener(SetPlayerName); 
    }
    
    public void SetPlayerName(string value)
    {
        PhotonNetwork.NickName = value + " ";   
        PlayerPrefs.SetString(playerNamePrefKey, value); 
        Debug.Log(PhotonNetwork.LocalPlayer.NickName); 
    }   
}
