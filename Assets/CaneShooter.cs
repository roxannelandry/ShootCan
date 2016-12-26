using UnityEngine;
using System.Collections;

public class CaneShooter : MonoBehaviour {

	public Rigidbody rock;
	public Transform positionOfShooting;
	public float shootForce;
	public float moveSpeed;

	public void Start () {
		
	}
	
	public void Update () {
		float h = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;

		transform.Translate (new Vector3 (h, 0, 0));

		if (Input.GetButtonUp ("Fire1")) {
			Rigidbody shoot = (Rigidbody) Instantiate (rock, positionOfShooting.position, positionOfShooting.rotation);
			shoot.AddForce (positionOfShooting.forward * shootForce);
		}
	}
}
