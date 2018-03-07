using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomDialogManager : MonoBehaviour
{
	public GameObject ErrorDisplay;

	public string RoomName { get; private set; }

	private RectTransform Transform
	{
		get { return ((RectTransform) gameObject.transform); }
	}

	private void Start()
	{
		RoomName = "";
	}

	public void SetOpen(bool open)
	{
		gameObject.SetActive(open);
		Transform.sizeDelta = new Vector2(Transform.sizeDelta.x, 135);

		if (!open)
		{
			ErrorDisplay.SetActive(false);
		}
	}

	public void SetRoomName(string roomName)
	{
		RoomName = roomName;
	}

	private void SetError(string error)
	{
		ErrorDisplay.GetComponent<Text>().text = error;
		ErrorDisplay.SetActive(true);
		Transform.sizeDelta = new Vector2(Transform.sizeDelta.x, 180);
	}

	public void CreateRoom()
	{
		if (RoomName.Equals(""))
		{
			SetError("Please enter a room name.");
			return;
		}

		PhotonNetwork.CreateRoom(RoomName);
	}

	private void OnCreatedRoom()
	{
		SetOpen(false);
	}

	private void OnPhotonCreateRoomFailed()
	{
		SetError("Room with that name already exists.");
	}
}