using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class H_PhotonNetworkManager : Photon.PunBehaviour
{

    [SerializeField] private string ServerName;
    [SerializeField] private Text ConnectText;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject Player;

    private void Start ()
    {
        PhotonNetwork.ConnectUsingSettings(ServerName);
    }
    
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("HenryRoom", null, null);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(Player.name, SpawnPoint.position, SpawnPoint.rotation, 0);
    }

    private void Update()
    {
        ConnectText.text = PhotonNetwork.connectionStateDetailed.ToString();
    }
}
