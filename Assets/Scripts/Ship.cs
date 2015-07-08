using UnityEngine;
using System.Collections;

/**
 * The ship class handles the basic functionality for any ship (enemy, player)
 */
public abstract class Ship : MonoBehaviour
{
	/**
	 * The ships speed
	 */
	public float speed = 100f;


	/**
	 * The ship will collide with objects of the given tag
	 */
	public Enum.Tags collideWith;


	/**
	 * The ships life amount
	 * If the life is reduced to 0 the ship will be destroyed
	 */
	public int life
	{
		get
		{
			return this._life;
		}
		set
		{
			this._life = value;

			if (this._life <= 0)
			{
				this.Destroy();
			}
		}
	}


	/**
	 * The interal ship life counter
	 */
	[SerializeField]
	private int _life = 1;


	/**
	 * Rotate left axis
	 */
	protected Vector3 rotateLeftAxis = new Vector3(0, 0, -1);


	/**
	 * Rotate right axis
	 */
	protected Vector3 rotateRightAxis = new Vector3(0, 0, 1);



	/**
	 * Rotates the ship around the center
	 */
	protected void RotateAround(Vector3 rotateAxis)
	{
		this.transform.RotateAround(Config.screenCenter, rotateAxis, Time.deltaTime * this.speed);
	}


	/**
	 * Handles collision of a missile with the ship
	 */
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag(this.collideWith.ToString()))
		{
			var missile = collider.GetComponent<Missile>();
			if (missile != null)
			{
				missile.Deactivate();

				this.life --;
			}
		}
	}



	/**
	 * Is automaticly called if the ship is destroied
	 */
	protected abstract void Destroy();
}
