using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
	public GameObject PlayerListObject;
	public GameObject PlayerDisplayPrefab;

	private void OnGUI()
	{
		foreach (Transform t in PlayerListObject.transform)
		{
			Destroy(t.gameObject);
		}

		Debug.Log(PhotonNetwork.playerList.Length);

		for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
		{
			PhotonPlayer player = PhotonNetwork.playerList[i];

			GameObject playerDisplay = Instantiate(PlayerDisplayPrefab, PlayerListObject.transform);
			playerDisplay.GetComponent<Text>().text = player.NickName;

			playerDisplay.transform.localPosition = new Vector3(
				playerDisplay.transform.localPosition.x,
				playerDisplay.transform.localPosition.y - ((RectTransform) playerDisplay.transform).rect.height* i
				);
		}
	}
}