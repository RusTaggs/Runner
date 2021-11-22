using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Entity : MonoBehaviour
{
	public int _health;
	public int _damage;
	public static int _score;

	public virtual void TakeDamage(int damage, GameObject obj)
	{
		if (_health > 0)
		{
			_health -= damage;
			Debug.Log(_health);
			if (_health <= 0)
			{
				Die(obj);
			}
		}
	}

	public virtual void Die(GameObject obj)
	{
		Destroy(obj);
	}
}
