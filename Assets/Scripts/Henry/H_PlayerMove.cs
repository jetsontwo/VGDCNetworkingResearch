using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerMove : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private PhotonView pView;
	
	// Update is called once per frame
	void Update () {
        if (pView.isMine == false)
            return;

        Vector3 newPosition = transform.position;
        newPosition += Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        newPosition += Vector3.up * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        transform.position = newPosition;
	}
}
