using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColision : MonoBehaviour
{
	Vector2 playerposition;

	private void OnTriggerEnter2D(Collider2D collision)
	{


		if (collision.gameObject.CompareTag("Player"))
		{
			playerposition = collision.gameObject.transform.position;


		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		

		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.transform.position = playerposition;

		}
	}
	
}
