using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
 
public class GameManager : MonoBehaviourPunCallbacks
{
    private GameObject playerPrefab; 
 
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Launcher");
            return; 
        }


        GameObject canvas_obj = GameObject.Find("Canvas");

        playerPrefab = Resources.Load("player",  typeof(GameObject)) as GameObject;
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, canvas_obj.transform.position, Quaternion.identity, 0);
        player.transform.SetParent(canvas_obj.transform);
    }
 
    // Update is called once per frame
    void Update () {
		
	}
}