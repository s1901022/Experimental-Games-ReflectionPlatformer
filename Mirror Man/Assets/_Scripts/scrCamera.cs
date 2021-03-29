using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCamera : MonoBehaviour {

	GameObject[] barriers = new GameObject[4];

	[SerializeField]
	Transform target;

	float smoothSpeed = 5f;

	Vector3 offset = new Vector3(0, 0, -6);

	float halfHeight;
	float halfWidth;

	private void Start() {
		// player is the target position
		target = GameObject.FindGameObjectWithTag("Player").transform;

		// TOP & BOTTOM
		barriers[0] = GameObject.FindGameObjectWithTag("BarrierTop");
		barriers[1] = GameObject.FindGameObjectWithTag("BarrierBottom");
		// LEFT & RIGHT
		barriers[2] = GameObject.FindGameObjectWithTag("BarrierLeft");
		barriers[3] = GameObject.FindGameObjectWithTag("BarrierRight");
	}

	void Update() {
		//halfHeight = Camera.main.orthographicSize;
		//halfWidth = Camera.main.aspect * halfHeight;

		// if the camera is within the barriers
		//if ((transform.position.x - halfWidth > barriers[2].transform.position.x && transform.position.x + halfWidth < barriers[3].transform.position.x) || (transform.position.y - halfHeight > barriers[1].transform.position.y && transform.position.y + halfHeight < barriers[0].transform.position.y)) {
			// lerp towards the player
			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
			transform.position = smoothedPosition;
		//}
	}
}
