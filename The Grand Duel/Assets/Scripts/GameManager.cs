using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public string playerPrefabLocation;

    public static GameManager instance;
    private int playersInGame = 0;

    public PlayerController[] players;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        players = new PlayerController[PhotonNetwork.PlayerList.Length];
        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
    }
    void Update()
    {
        
    }

    [PunRPC]
    void ImInGame()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
            SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabLocation, new Vector3(0, 10, 0), Quaternion.identity);

        PlayerController playerScipt = playerObj.GetComponent<PlayerController>();

        playerScipt.enabled = true;
        playerScipt.photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }

}
