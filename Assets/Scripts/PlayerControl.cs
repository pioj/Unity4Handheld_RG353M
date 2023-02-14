using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public Transform Player;

	public float speed;
	public float jumpForce;
	private Rigidbody2D _rb;

	void Awake()
	{
		_rb = Player.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Movement();
		Jump();
	}

	public void Jump()
	{
		if (Input.GetButtonDown("ButtonB"))
		{
			_rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
		}
	}

	public void Movement()
	{
		if (Input.GetAxis("LeftAnalogX") < 0f)
		{
			Player.Translate(-1f * speed * Time.deltaTime, 0f, 0f);
		}
		else if (Input.GetAxis("LeftAnalogX") > 0f)
		{
			Player.Translate(1f * speed * Time.deltaTime, 0f ,0f);
		}
	}

	
}
