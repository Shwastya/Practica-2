using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

	

	public float acceleration = 6f;
	public float turnAcceleration = 5f;

	public GameObject bulletPrefab = null;
	public Rigidbody rigid = null;

	protected int lives = 3;
	private int bases = 0;
	
	private float power = 5.0f;
	private float radius = 1.0f;
	private float upforce = 1f;

	public void shot()
	{
		GameObject bullet = Instantiate(bulletPrefab);

		bullet.tag = "Player";

		bullet.GetComponent<Transform>().position = transform.position + (transform.forward * .15f);
		bullet.GetComponent<BulletBehaviour>().setDirection(transform.forward);

		Destroy(bullet, 1f);
	}

	public void baseFounded()
	{
		bases++;
		lives = 3;

		if (bases == 4)
		{
			Debug.Log("¡¡ Fin del juego !!");			
		}
	}

	public void hit(Vector3 BulletDir)
	{
		if (lives <= 0)
		{
			Debug.Log("Player: Nave destruida");
			gameObject.SetActive(false);
		}
		else
		{
			lives--;
			rigid.AddExplosionForce(power, transform.position - BulletDir, radius, upforce, ForceMode.Impulse);
			Debug.Log("Player: Daño recibido!!");
		}
	}

	void Update()
	{       
		if (Input.GetKeyDown(KeyCode.Space))
		{
			shot();
		}
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			rigid.AddRelativeForce(Vector3.forward * acceleration, ForceMode.Acceleration);
		}
			
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			rigid.AddRelativeForce(-Vector3.forward * acceleration, ForceMode.Acceleration);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigid.AddTorque(-Vector3.up * turnAcceleration, ForceMode.Acceleration);
		}
			
		else if (Input.GetKey(KeyCode.RightArrow)) 
		{
			rigid.AddTorque(Vector3.up * turnAcceleration, ForceMode.Acceleration);
		}
	}
}