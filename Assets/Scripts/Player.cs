using UnityEngine;
using System.Collections;

/**
 * The player class handles the player inputs and the player ship behaviour
 */
public class Player : Ship
{
	/**
	 * Handles the player inputs
	 */
	private void Update ()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.RotateAround(this.rotateRightAxis);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.RotateAround(this.rotateLeftAxis);
		}
	}


	/**
	 * Destroies the players ship
	 */
	protected override void Destroy ()
	{
		Debug.Log ("player destroied!");
	}
}
