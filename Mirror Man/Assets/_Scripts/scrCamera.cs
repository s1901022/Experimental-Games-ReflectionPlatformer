using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCamera : MonoBehaviour {
	[SerializeField]
	Transform target;

	float smoothSpeed = 5f;

	Vector3 offset = new Vector3(0, 0, -6);

	private void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate() {
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
