using UnityEngine;
using System.Collections;

/**
 * The player class handles the player inputs and the player ship behaviour
 */
public class Player : Ship
{
	/**
	 * The players spawn position
	 */
	[SerializeField]
	private Vector3 spawnPosition;


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
	 * Reduce the players lifes
	 */
	protected override void ReduceLife()
	{
		// TODO: Add hit vfx

		this.life --;
		Game.SetLifesUI(this.life);
		if (this.life == 0)
		{
			this.Destroy();
		}
	}


	/**
	 * Destroies the players ship
	 */
	protected override void Destroy()
	{
		// TODO: Add destroy vfx
		this.Deactivate();
	}


	/**
	 * Resets the enemy ships values
	 */
	protected override void Reset()
	{
		this.transform.position = this.spawnPosition;
		this.life = 5; // TODO: replace hardcoded life reset
		Game.SetLifesUI(this.life);
	}
}
