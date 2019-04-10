using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour 
{
    #region Variables
    float speed = 5f;
    [SerializeField]
	float paddleSpeed;
    [SerializeField]
    float clampLength;
    [SerializeField]
    private Vector3 initialPlayerPosition = new Vector3 (0, -15f, 0);
	//Vector3 lastPosition = Vector3.zero;
	//public float Speed = 0f;
	//public Vector3 localDirection = Vector3.zero;
	//public Vector3 targetPosition;
	//private Vector3 distance;
	//Vector3 direction = Vector3.zero;
    #endregion

	void Update () 
	{
		Move ();
	}

	void Move ()
	{
        float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        initialPlayerPosition = new Vector3(Mathf.Clamp(xPosition, -clampLength, clampLength), initialPlayerPosition.y, 0f);
        transform.position = initialPlayerPosition;
        /* ~ Old Way Using The Mouse
        Vector3 clampedPosition = transform.position;
        float xMove = Input.mousePosition.x;
        transform.Translate(0f, xMove, 0f);
		clampedPosition.x = Mathf.Clamp (transform.position.x, -9.5f, 0f);
        transform.position = clampedPosition;
		float distance = Input.mousePosition.z + 27.5f;
		targetPosition = new Vector3 (Input.mousePosition.x, -9.5f + 100, distance);
		targetPosition = Camera.main.ScreenToWorldPoint (targetPosition);
		transform.position = Vector3.MoveTowards (targetPosition, targetPosition, paddleSpeed * Time.deltaTime);
        */
    }

    void FixedUpdate()
	{
        /*
		Speed = (transform.position - lastPosition).magnitude;
		direction = (transform.position - lastPosition);
		localDirection = transform.InverseTransformDirection (direction); 
		lastPosition = transform.position;
        */
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Upgrade")
		{
			transform.localScale += new Vector3(12, 1, 1);
			Destroy (gameObject);
		}
	}
}
