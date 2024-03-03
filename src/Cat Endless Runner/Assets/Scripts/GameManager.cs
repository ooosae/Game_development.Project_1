using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
	private int distance = 0;
    public static GameManager inst;
	[SerializeField] private TMP_Text dictanceText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private PlayerController playerController;
    
    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        if (playerController.movementSpeed < playerController.maxSpeed)
            playerController.movementSpeed += playerController.speedIncreasePerPoint;
    }

	public void IncrementDistance() {
		distance++;
        dictanceText.text = "DISTANCE: " + distance;
	}

	public void DoBoost() {
		playerController.Boost();
	}
    
    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
	
    }

	public int GetDistance()
	{
		return distance;
	}

    private float timer = 0f;
	private float incrementInterval = 0.1f;

	void Update()
	{
		if (playerController.alive)
		{
    		timer += Time.deltaTime;
    		if (timer >= incrementInterval)
    		{
       		IncrementDistance();
        		timer = 0f; 
    		}
		}
	}
}
