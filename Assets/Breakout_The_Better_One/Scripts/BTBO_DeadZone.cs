using UnityEngine;
using System.Collections;

public class BTBO_DeadZone : MonoBehaviour 
{
	// public GM gameManager
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Ball")
		{
            BTBO_GM.instance.LoseLife();
            Destroy(col.gameObject);
		}
		// GameManager.LoseLife();
	}
}
