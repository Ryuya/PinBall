using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreIncrement : MonoBehaviour
{

	public GameObject scoreText;
	public int incrementScore;
	// Use this for initialization
	void Start ()
	{
		scoreText = GameObject.Find ("ScoreText");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter (Collision other)
	{
		scoreText.GetComponent<Score> ().score += incrementScore;
	}
}
