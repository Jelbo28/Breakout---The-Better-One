using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
    #region Variables
    [SerializeField]
    float ballInitialVelocity;
    [SerializeField]
    float ballPaddleDistance;
    [SerializeField]
    GameObject paddle;
    private Rigidbody ballRigidbody;
    private bool ballInPlay;
	//private Vector3 paddleTransform;
	//float paddleSpeed = 0f;
	//public Vector3 paddleDirection = Vector3.zero;
    //private Vector3 ballDirection = Vector3.zero;
	//private Quaternion Rotation;
    #endregion
    // Use this for initialization
    void Awake () 
	{
		ballRigidbody = GetComponent<Rigidbody> ();
	}

    void Update()
    {
		//FixBouncing ();
        if (ballInPlay == false)
        {
            //BallPlacement();
            if (Input.GetButtonDown("Jump"))
            {
                //Debug.Log (Input.GetAxis("Mouse X"));
                transform.parent = null;
                ballInPlay = true;
                ballRigidbody.isKinematic = false;
                //ballRigidbody.AddForce(new Vector3(/*ballInitialVelocity*/ (paddleSpeed * 1000), 0, 0));
                ballRigidbody.velocity = new Vector3 (ballInitialVelocity, ballInitialVelocity, 0);
                //ballRigidbody.AddForceAtPosition (transform.right * paddleSpeed, 0);
            }
        }
    }

    /*
    void BallPlacement()
    {
        Vector3 ballPosition = new Vector3(paddle.transform.position.x, (paddle.transform.position.y + ballPaddleDistance));
        transform.position = ballPosition;
    }
    */
    
    /*
	void FixBouncing ()
	{
		if (Input.GetButtonDown("Jump"))
		{
			ballRigidbody.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
    }

    void FindPaddleSpeed()
	{
		GameObject paddle = GameObject.Find("Paddle(Clone)");
		Paddle paddleScript = paddle.GetComponent<Paddle> ();
		paddleSpeed = paddleScript.Speed;
		paddleDirection = paddleScript.localDirection;
		paddleTransform = paddleScript.targetPosition;
	}
    */
    
    /*
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (paddleDirection.x > 0)
			{
				ballRigidbody.AddForce(new Vector3((paddleSpeed * 1000), 0, 0));
			}
			else
			{
				ballRigidbody.AddForce(new Vector3((paddleSpeed * 1000), 0, 0));
			}
	    }
	}
    */
}
