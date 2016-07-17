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
        List<int> choices = new List<int>() { 0, 90, 180, 270 };

        while (choices.Count > 0)
        {
            int index = rand.Next() % choices.Count;
            int choice = choices[index];
            Debug.Log("the next random number : " + choice);
            choices.RemoveAt(index);
        }
    }
}
