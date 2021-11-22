using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Enemy : Obstacle
{
	private PlayerMovement player;

	
	
	private void Start()
	{
		player = FindObjectOfType<PlayerMovement>();
	}

	private void Update()
	{
		Move();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Bullet")
		{
			TakeDamage(player._damage, gameObject);
		}
	}

	public override void Die(GameObject obj)
	{
		base.Die(obj);
		_score++;
	}
}
