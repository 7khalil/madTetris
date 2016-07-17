using UnityEngine;
using System.Collections;

public class Clamp : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player"){
			Debug.Log ("the player Exit from the PlayGround !");
			Debug.Log ("GitHub Test");
		}
	}
}
