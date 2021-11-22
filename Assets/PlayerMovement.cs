using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : Entity
{
	[SerializeField]
    private float jumpForce = 30f;

	[SerializeField]
	private GameObject aim;

	[SerializeField]
	private GameObject bullet;

	[SerializeField]
	private Transform groundCheck;

	[SerializeField]
	private LayerMask groundMask;

	[SerializeField]
	private float groundCheckRadius;

	[SerializeField]
	private bool isImmortal = false;

	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text distanceText;

	private float distance = 0;
	private float distanceInterval = 1;

	[SerializeField]
	private int bonusPoints = 10;
	[SerializeField]
	private int scoreBonus = 10;

	private bool isGrounded = true;

    private Rigidbody2D rb;
	public Obstacle obstacle;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (_health <= 0)
		{
			Die(gameObject);
		}
		if (DistanceCounter() == bonusPoints)
		{
			_score += scoreBonus;

			bonusPoints *= 2;
			scoreBonus *= 2;
		}

		scoreText.text = "Score: " + _score.ToString();
		distanceText.text = DistanceCounter().ToString();
		

		if (Input.GetKeyDown(KeyCode.Space))
		{
			CheckGround();
			if (isGrounded)
			{
				rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Fire");
			Fire();
		}
	}

	private int DistanceCounter()
	{
		distance += Time.deltaTime * distanceInterval;
		return (int)distance;
	}

	private void Fire()
	{
		Instantiate(bullet, aim.transform);
	}

	private bool CheckGround()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
		return isGrounded;
	}

	

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Obstacle" && isImmortal == false)
		{
			TakeDamage(obstacle._damage, gameObject);
		}
	}

}
