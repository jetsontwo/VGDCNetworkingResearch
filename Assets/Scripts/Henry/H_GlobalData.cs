using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class H_GlobalData : Photon.PunBehaviour {

    [SerializeField] private Text ClickedCount;
    [SerializeField] private int clicked;
    [SerializeField] private PhotonView pView;
    
    public override void OnJoinedRoom()
    {
        clicked = 0;
        UpdateCount();
    }

    public void ClickButton()
    {
        if (PhotonNetwork.inRoom == false)
            return;

        if (pView.isMine == false)
            pView.RPC("SendClick", pView.owner);

        clicked += 1;
        UpdateCount();
    }

    public void UpdateCount()
    {
        ClickedCount.text = clicked.ToString();
    }

    [PunRPC]
    private void SendClick()
    {
        ClickButton();
    }

    public void OnPhotonSerializeView(PhotonStream photonStream, PhotonMessageInfo info)
    {
        if(photonStream.isWriting)
        {
            photonStream.SendNext(clicked);
        }

        else if(photonStream.isReading)
        {
            clicked = (int)photonStream.ReceiveNext();
            UpdateCount();
        }
    }
}
