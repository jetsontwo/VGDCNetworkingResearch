using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkDisplay : MonoBehaviour
{
	public Text ConnectionState;
	public GameObject RoomList;
	public GameObject RoomDisplayPrefab;
	public Button JoinRoomButton;

	public CreateRoomDialogManager DialogManager;

	private void OnGUI()
	{
		ConnectionState.text = PhotonNetwork.connectionStateDetailed.ToString();
	}

	public void OpenCreateRoomDialog()
	{
		DialogManager.SetOpen(true);
	}

	internal void SetJoinRoomInteractable(bool interactable)
	{
		JoinRoomButton.interactable = interactable;
	}

	public void OnReceivedRoomListUpdate()
	{
		foreach (Transform t in RoomList.transform)
		{
			Destroy(t.gameObject);
		}

		RoomInfo[] rooms = PhotonNetwork.GetRoomList();

		for (int i = 0; i < rooms.Length; i++)
		{
			GameObject roomDisplay = Instantiate(RoomDisplayPrefab, RoomList.transform);

			// Set position
			roomDisplay.transform.localPosition = new Vector3(
				roomDisplay.transform.localPosition.x,
				roomDisplay.transform.localPosition.y - ((RectTransform) roomDisplay.transform).rect.height * i
			);

			// Set RoomInfo
			RoomOptionManager roomOptionManager = roomDisplay.GetComponent<RoomOptionManager>();
			Debug.Log(roomOptionManager);
			roomOptionManager.Room = rooms[i];
		}
	}
}