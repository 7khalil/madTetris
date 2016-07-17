using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxJumpPressure;
	public float speed;

	private float jumpPressure;
	private float minJumpPressure;
	private bool onGround;

	float screenHalfWidthInWorldUnit;
	float screenHalfHeightInWorldUnit;
	Rigidbody rigBody;

	void Start()
	{
		rigBody = GetComponent<Rigidbody> ();
		//onGround = true;
		minJumpPressure = 2f;
		jumpPressure = 0f;

		float halfPlayerWidth = transform.localScale.x / 2f;
		float halfPlayerHeight = transform.localScale.y / 2f;
		screenHalfWidthInWorldUnit = Camera.main.orthographicSize * Camera.main.aspect - halfPlayerWidth;
		screenHalfHeightInWorldUnit = Camera.main.orthographicSize - halfPlayerHeight;
	}


	void Update()
	{
		//moving the player...
		Vector3 input = new Vector3 (Input.GetAxis ("Horizontal"), 0f, 0f);
		Vector3 direction = input.normalized;
		Vector3 velocity = direction * speed;
		Vector3 moveAmount = velocity * Time.deltaTime;

		transform.position += moveAmount;

		if (transform.position.x < -screenHalfWidthInWorldUnit) {
			transform.position = new Vector2 (-screenHalfWidthInWorldUnit, transform.position.y);
		}
		if (transform.position.x > screenHalfWidthInWorldUnit) {
			transform.position = new Vector2 (screenHalfWidthInWorldUnit, transform.position.y);
		}
		if (transform.position.y < -screenHalfHeightInWorldUnit) {
			onGround = true;
			transform.position = new Vector2 (transform.position.x,-screenHalfHeightInWorldUnit);
		}
		//jumping the player...
		if (onGround) {
			if (Input.GetButton ("Jump")) {
				if (jumpPressure < maxJumpPressure) {
					Debug.Log ("the space button is pressed");
					jumpPressure += Time.deltaTime * 10;
				} else {
					jumpPressure = maxJumpPressure;
				}
			} else {
				if(jumpPressure > 0f){
					jumpPressure += minJumpPressure; 
					rigBody.velocity = new Vector3 (Input.GetAxis ("Horizontal") * 10, jumpPressure, 0f);
					jumpPressure = 0f;
					onGround = false;
				}
			}
		}
	}
}
