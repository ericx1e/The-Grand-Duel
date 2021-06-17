using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPunCallbacks
{

    private Player photonPlayer;
    private int id;
    private bool isMine;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    [PunRPC]
    public void Initialize(Player player)
    {
        photonPlayer = player;
        id = player.ActorNumber;

        GameManager.instance.players[id - 1] = this;
        isMine = photonView.IsMine;
    }

}
