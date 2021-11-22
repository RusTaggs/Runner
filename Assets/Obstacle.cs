using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Entity
{
    [SerializeField]
    private float speed = 2f;

	private void Update()
	{
		Move();
	}

	public void Move()
	{
		transform.position += Vector3.left * speed * Time.deltaTime;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(collision.collider.tag);
		if (collision.collider.name == "Destroyer")
		{
			
			Destroy(gameObject);
		}
	}


}
