using UnityEngine;
using System.Collections;

/**
 * The player class handles the player inputs and the player ship behaviour
 */
public class Player : Ship
{
	/**
	 * The missile object pool component
	 */
	private ObjectPool missileObjectPool;


	/**
	 * Grep and cache needed components
	 */
	private void Start()
	{
		this.Activate();
		this.missileObjectPool = this.GetComponent<ObjectPool>();
	}


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

		if (Input.GetKeyDown(KeyCode.Space) && this.nextFire <= Time.time)
		{
			var objectPoolEntity = this.missileObjectPool.GetObjectPoolEntity();
			objectPoolEntity.Activate(this.transform.position);
			this.nextFire = Time.time + this.fireDelay;
		}
	}


	/**
	 * Activates the players ship
	 */
	public void Activate()
	{
		this.Reset();
		this.gameObject.SetActive(true);
	}


	/**
	 * Deactivates the players ship
	 */
	public void Deactivate()
	{
		this.gameObject.SetActive(false);
	}


	/**
	 * Destroies the players ship
	 */
	protected override void Destroy()
	{
		this.Deactivate();
	}


	/**
	 * Resets the enemy ships values
	 */
	protected override void Reset()
	{
		this.life = 5; // TODO: remove hardcoded life reset
	}
}
