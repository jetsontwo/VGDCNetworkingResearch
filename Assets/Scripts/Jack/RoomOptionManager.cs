using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RoomOptionManager : MonoBehaviour
{
	public RoomInfo Room;
	private Text _roomNameText;
	private Image _background;

	private void Start()
	{
		_roomNameText = GetComponentInChildren<Text>();
		_roomNameText.text = Room.Name;
		_background = GetComponent<Image>();

		GetComponent<Button>().onClick.AddListener(() => NetworkManager.Instance.SelectRoom(Room));
	}

	private void OnGUI()
	{
		bool selected = ReferenceEquals(NetworkManager.Instance.SelectedRoom, Room);

		_roomNameText.fontStyle = selected ? FontStyle.Italic : FontStyle.Normal;
		_background.color = selected ? new Color(1f, 0.97f, 0.67f) : Color.white;
	}
}