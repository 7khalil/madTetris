using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	void Update()
	{
		Vector3 input = new Vector3 (Input.GetAxis ("Horizontal"), 0f, 0f);
		Vector3 direction = input.normalized;
		Vector3 velocity = direction * speed;
		Vector3 moveAmount = velocity * Time.deltaTime;

		transform.position += moveAmount;
	}


}
