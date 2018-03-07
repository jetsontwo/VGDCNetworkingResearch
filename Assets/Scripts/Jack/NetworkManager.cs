using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class NetworkManager : MonoBehaviour
{
	public static NetworkManager Instance;
	public NetworkDisplay Display;

	public RoomInfo SelectedRoom { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.0.1");
	}

	public void SetPlayerName(string playerName)
	{
		PhotonNetwork.playerName = playerName;
	}
	
	private void OnJoinedLobby()
	{
		Debug.Log(PhotonNetwork.lobby);
	}

	public void SelectRoom(RoomInfo room)
	{
		if (Equals(SelectedRoom, room))
		{
			SelectedRoom = null;
			Display.SetJoinRoomInteractable(false);
		}
		else
		{
			SelectedRoom = room;
			Display.SetJoinRoomInteractable(true);
		}
	}

	private string RandomName()
	{
		const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
		StringBuilder builder = new StringBuilder();
		Random rng = new Random();

		for (int i = 0; i < 8; i++)
		{
			char c = pool[rng.Next(0, pool.Length)];
			builder.Append(c);
		}

		return builder.ToString();
	}

	public void JoinRoom()
	{
		PhotonNetwork.JoinRoom(SelectedRoom.Name);
	}

	private void OnJoinedRoom()
	{
		if (PhotonNetwork.playerName.Equals(""))
		{
			PhotonNetwork.playerName = RandomName();
		}
		SceneManager.LoadScene("Room");
	}
}