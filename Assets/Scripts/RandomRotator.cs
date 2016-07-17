using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomRotator : MonoBehaviour {

	Rigidbody rigBody;

	void Start()
	{
		rigBody = GetComponent<Rigidbody> ();
		//rigBody.rotation = Random.rotationUniform;

        System.Random rand = new System.Random();
		var i = 10;
		while (i > 0) {

			Debug.Log("the next random number : " + rand.Next (0, 5) * 90);
			i--;
		}
    }
}
