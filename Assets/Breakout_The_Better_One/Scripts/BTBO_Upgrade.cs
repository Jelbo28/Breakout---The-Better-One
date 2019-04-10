using UnityEngine;
using System.Collections;

public class BTBO_Upgrade : MonoBehaviour 
{
	Vector3 Position;
	float fallSpeed = -5;

	/*
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log ("Player Contacted");
			Destroy (gameObject);
		}
	}
	*/

	void FixedUpdate()
	{
		transform.position = Position;
		Position.y += (fallSpeed * Time.deltaTime);
	}
}
