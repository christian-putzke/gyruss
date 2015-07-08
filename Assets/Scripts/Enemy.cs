using UnityEngine;
using System.Collections;

/**
 * The enemy class handles the enemy ship behaviour
 */
public class Enemy : Ship, IObjectPoolEntity
{
	/**
	 * The score that the player will gain if the enemy gets destroied
	 */
	public int score = 100;


	/**
	 * The range between fireDelay and maxFireDelay results in a random fire mechanic
	 */
	public float maxFireDelay = 5f;


	/**
	 * The missiles target object
	 */
	private GameObject missileTargetObject;


	/**
	 * The missiles target object
	 */
	private ObjectPool missileEnemyObjectPool;


	/**
	 * Grep needed components and objects
	 * - Sets the missiles target object to the player on start up
	 * - Greps the missile enemy object pool
	 */
	private void Start()
	{
		this.missileTargetObject				= GameObject.FindGameObjectWithTag(Enum.Tags.Player.ToString());
		var missileEnemyObjectPoolGameObject	= GameObject.FindGameObjectWithTag(Enum.Tags.MissileEnemyObjectPool.ToString());
		this.missileEnemyObjectPool				= missileEnemyObjectPoolGameObject.GetComponent<ObjectPool>();
	}


	/**
	 * Handles the enemy behaviour (movement and missiles)
	 */
	private void Update()
	{
		if (this.IsActive() && this.nextFire <= Time.time)
		{
			var missileEnemy = (MissileEnemy) this.missileEnemyObjectPool.GetObjectPoolEntity();
			missileEnemy.SetTarget(this.missileTargetObject.transform.position);
			missileEnemy.Activate(this.transform.position);
			this.CalculateNextFireTime();
		}
	}


	/**
	 * Calculates the next fire time
	 */
	private void CalculateNextFireTime()
	{
		this.nextFire = Time.time + Random.Range(this.fireDelay, this.maxFireDelay);
	}


	/**
	 * Activates the enemy
	 */
	public void Activate(Vector3 spawnPosition)
	{
		this.CalculateNextFireTime();
		this.gameObject.SetActive(true);
	}


	/**
	 * Deactivates the enemy
	 */
	public void Deactivate()
	{
		this.gameObject.SetActive(false);
	}


	/**
	 * Returns true if the enemy is active
	 */
	public bool IsActive()
	{
		return this.gameObject.activeSelf;
	}


	/**
	 * Destroies the enemies ship
	 */
	protected override void Destroy()
	{
		this.Deactivate();
		this.Reset();

		// TODO: Notify the game that the player gained score points
	}


	/**
	 * Resets the enemy ships values
	 */
	protected override void Reset()
	{
		this.life = 1; // TODO: remove hardcoded life reset
	}
}
