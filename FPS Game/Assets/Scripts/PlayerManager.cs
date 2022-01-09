using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;
 
 public class PlayerManager : MonoBehaviourPunCallbacks
{
    PhotonView PV;

    GameObject controller;

    int index;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        index = 0;
    }

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            foreach (var pl in PhotonNetwork.PlayerList)
            {
                photonView.RPC("CreateController", pl, this.index, pl.NickName);
                this.index++;
            }
        }
    }

    [PunRPC]
    void CreateController(int index, string nickname)
    {
        if (!PV.IsMine)
        {
            return;
        }
		Debug.LogError(index);
        Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint(index);
        controller =
            PhotonNetwork
                .Instantiate(Path
                    .Combine("PhotonPrefabs", "ThirdPersonController"),
                spawnpoint.position,
                spawnpoint.rotation,
                0,
                new object[] { PV.ViewID });

    }

    public void Die()
    {
        PhotonNetwork.Destroy (controller);
        // CreateController();
    }
}