﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour 
{
    #region Variables
    [SerializeField]
    int lives = 3;
    [SerializeField]
	int score = 0;
    [SerializeField]
	int bricks = 0;

    [SerializeField]
    float resetDelay = 1f;
    [SerializeField]
    Text livesText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    GameObject youWon;
    [SerializeField]
    GameObject paddle;
    [SerializeField]
    GameObject deathParticles;
    [SerializeField]
    GameObject Screen;

	Animator anim;

	public static GM instance = null;

	private GameObject clonePaddle;
	private GameObject Bricks;

	AudioSource brickDestroy;
	AudioSource paddleDeath;
    #endregion

    void Awake () 
	{
		livesText.text = "Lives: 3";
		scoreText.text = "Score: 0";
		gameOver.SetActive(false);
		AudioSource[] audios = GetComponents<AudioSource>();
		brickDestroy = audios[0];
		paddleDeath = audios[1];
		anim = Screen.GetComponent<Animator> ();
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		CheckLevel ();
		Setup ();

	}

	public void Setup()
	{
		//Debug.Log ("Paddle");
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	void CheckGameover()
	{
		if (bricks < 1) 
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

		if (lives < 1) 
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
			anim.SetTrigger("Gameover");
		}
	}

	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void LoseLife()
	{
		paddleDeath.Play();
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("Setup", resetDelay);
		CheckGameover ();
	}

	public void DestroyBrick()
	{
		bricks--;
		score = score + 100;
		scoreText.text = "Score: " + score;
		brickDestroy.Play();
		CheckGameover();
	}

    public void HitBrick()
    {
        score = score + 10;
        scoreText.text = "Score: " + score;
    }

    public void CheckLevel()
	{
		switch(Application.loadedLevelName)
		{
		case "Level 01":
			bricks = 20;
			break;
		case "Level 02":
			bricks = 2;
			break;
		}
	}

    /*
	void HotFix()
	{
		if (Input.GetButtonDown("a"))
		{
			LoseLife();
			lives++;
			livesText.text = "Lives: " + lives;
		}
	}
    */
}
