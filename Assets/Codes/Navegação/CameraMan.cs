using UnityEngine;
using System.Collections;

public class CameraMan : MonoBehaviour {
	
	public GameObject objectToFollow;

	public float speed = 2.0f;

	private float hastex;

	private float hastey;

	private float hastez;

	void Start() {

		GetMeDistance ();

	}

	void FixedUpdate () {
		float interpolation = speed * Time.deltaTime;

		Vector3 position = transform.position;
		position.y = Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y+hastey, interpolation);
		position.x = Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x+hastex, interpolation);
		position.z = Mathf.Lerp(transform.position.z, objectToFollow.transform.position.z+hastez, interpolation);

		this.transform.position = position;
	}

	void GetMeDistance() {
		float distancey = transform.position.y - objectToFollow.transform.position.y;
		float distancex = transform.position.x - objectToFollow.transform.position.x;
		float distancez = transform.position.z - objectToFollow.transform.position.z;

		hastey = distancey;
		hastex = distancex;
		hastez = distancez;

	}
}
