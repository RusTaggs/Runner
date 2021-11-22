using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	private float speed;

	private PlayerMovement player;
	private Enemy enemy;

	private void Start()
	{
		enemy = FindObjectOfType<Enemy>();
		player = FindObjectOfType<PlayerMovement>();
	}

	private void Update()
	{
		transform.position += Vector3.right * speed * Time.deltaTime;

		StartCoroutine(DeleteObject());
	}

	IEnumerator DeleteObject()
	{
		yield return new WaitForSeconds(10);
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
	}
}
