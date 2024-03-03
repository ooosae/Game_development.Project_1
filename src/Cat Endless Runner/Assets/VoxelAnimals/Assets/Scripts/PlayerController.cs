using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 9;
    [SerializeField] private float jumpForce = 300;
    [SerializeField] private float timeBeforeNextJump = 1.2f;
    [SerializeField] private float timeBeforeNextSlide = 1.2f;

    private float canJumpOrSlide = 0f;
    private float horizontalSpeedMultiplier = 1.5f;
    private Animator anim;
    private Rigidbody rb;
	
    public bool alive = true;
    public float speedIncreasePerPoint = 0.1f;
    public float maxSpeed = 20f;
	private bool isBoosted = false;
	

    void Start()
	{
    	anim = GetComponent<Animator>();
    	rb = GetComponent<Rigidbody>();
    	PlayerManager playerManager = FindObjectOfType<PlayerManager>(); 
        playerManager.SetPlayerController(this);
	}

    void Update()
    {
        ControllPlayer();
        if (transform.position.y < -2)
        {
            Die();
        }
    }

	public bool IsBoosted()
	{
		return isBoosted;
	}

    public void Boost()
    {
        anim.SetInteger("Boost", 1);
		isBoosted = true;
    }

    public void Deboost()
    {
        anim.SetInteger("Boost", 0);
		isBoosted = false;
    }

    void ControllPlayer()
    {
        if (!alive)
            return;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal * horizontalSpeedMultiplier / movementSpeed * 9, 0.0f, 1.0f);
        anim.SetInteger("Walk", 1);
        
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Slide") && Time.time > canJumpOrSlide)
        {
            canJumpOrSlide = Time.time + timeBeforeNextSlide;
            anim.SetTrigger("Slide");
        }

        if (Input.GetButtonDown("Jump") && Time.time > canJumpOrSlide)
        {
            rb.AddForce(0, jumpForce, 0);
            canJumpOrSlide = Time.time + timeBeforeNextJump;
            anim.SetTrigger("Jump");
            
        }
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 1);
    }
    void defeatScene()
    {
        SceneManager.LoadScene("Defeat");
    }
    void Restart()
    {
		int distance = GameManager.inst.GetDistance();
		RecordsManager.Instance.AddRecord(distance);
        defeatScene();
    }
}
