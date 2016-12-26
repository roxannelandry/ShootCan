using UnityEngine;
using System.Collections;

public class RaycastShootComplete : MonoBehaviour {

	public GameObject rock;
	private Camera fpsCam;												

	void Start () 
	{
		fpsCam = GetComponentInParent<Camera>();
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0.0f));

			rock = (GameObject)Instantiate (rock, rayOrigin, Quaternion.identity);

			float targetVelocity = 20.0f;
			float deceleration = 10f;

			RaycastHit hit;
			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, 50)) {

				Vector3 originToHit = (hit.transform.position - rayOrigin);

				float distance = originToHit.magnitude;
				float approxTimeToReach = distance / targetVelocity;

				float velocity = (distance + (deceleration * approxTimeToReach * approxTimeToReach) / 2) / approxTimeToReach;

				Vector3 gravityCompensation = (Physics.gravity * approxTimeToReach * approxTimeToReach / 2) * -1;

				Vector3 shotDirection = (originToHit + gravityCompensation).normalized;

				rock.GetComponent<Rigidbody> ().velocity = shotDirection * velocity;

			}
		
		}
	}
}