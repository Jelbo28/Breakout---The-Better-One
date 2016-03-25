using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour 
{
	public GameObject brickParticle;
	public GameObject Upgrade;
	private GameObject cloneUpgrade;
	public int collisionNumber = 0;
	float currentDelay = 0f;
	AudioSource collisionSound;
    public Texture Cracked1;
    public Texture Cracked2;
    public Texture Cracked3;
	float brickDrop = 0;


    void Awake ()
	{
		collisionSound = GetComponent<AudioSource> ();
		checkColorChange ();
	}

	void OnCollisionEnter (Collision other)
	{
		collisionSound.Play ();
		checkColorChange ();
		// Instantiate (brickParticle, transform.position, Quaternion.identity);
		// GM.instance.DestroyBrick();
		// Destroy(gameObject);
	}

	void checkColorChange()
	{
		Random rnd = new Random ();
		brickDrop = Random.Range(1, 6);
		//Debug.Log (brickDrop);
			/* int nextColor = int collisionNumber;*/
		switch (collisionNumber)
		{
		 default:
			collisionNumber++;
			break;
		case 0:
            transform.GetComponent<Renderer>().material.mainTexture = Cracked1;
            transform.GetComponent<Renderer>().material.color = Color.green;
            GM.instance.HitBrick();
            collisionNumber++;
			break;
		case 1:
            transform.GetComponent<Renderer>().material.mainTexture = Cracked2;
            transform.GetComponent<Renderer>().material.color = Color.yellow;
            GM.instance.HitBrick();
            collisionNumber++;
			break;
		case 2:
            transform.GetComponent<Renderer>().material.mainTexture = Cracked3;
            transform.GetComponent<Renderer>().material.color = Color.red;
            GM.instance.HitBrick();
            collisionNumber++;
			break;
		case 3:
			Instantiate (brickParticle, transform.position, Quaternion.identity);
			//SpawnItem ();
			GM.instance.DestroyBrick();
			Destroy(gameObject);
			break;
		}
	}

	void SpawnItem()
	{
		if (brickDrop >= 5)
		{
			cloneUpgrade = Instantiate (Upgrade, transform.position, Quaternion.identity) as GameObject;
			Debug.Log ("SpawnItem");
		}
	}
}
