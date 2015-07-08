using UnityEngine;
using System.Collections;

/**
 * The game class handles the whole game
 * TODO: Add game over / new game mechanic
 */
public class Game : MonoBehaviour
{
	/**
	 * The max amount of enemy objects (ships and missiles) on the screen
	 */
	public int maxEnemyObjects = 15;


	/**
	 * Maximal enemy swarm size
	 */
	public int maxEnemySwarmSize = 4;


	/**
	 * The distance between the enemies within one swarm
	 */
	public float distanceWithinEnemySwarms = 30f;


	/**
	 * The game total score
	 */
	private static int totalScore = 0;


	/**
	 * The game total score
	 */
	private static UI ui;


	/**
	 * The enemy object pool
	 */
	private ObjectPool enemyObjectPool;


	/**
	 * The enemy missile object pool
	 */
	private ObjectPool enemyMissileObjectPool;


	/**
	 * The players ship
	 */
	private Player player;


	/**
	 * Grep the needed components and objects on start up
	 */
	private void Awake()
	{
		this.enemyObjectPool = this.GetComponent<ObjectPool>();

		var enemyMissileObjectPoolGameObject	= GameObject.FindGameObjectWithTag(Enum.Tags.MissileEnemyObjectPool.ToString());
		this.enemyMissileObjectPool				= this.GetComponent<ObjectPool>();

		var playerGameObject	= GameObject.FindGameObjectWithTag(Enum.Tags.Player.ToString());
		this.player				= playerGameObject.GetComponent<Player>();

		Game.ui = this.GetComponent<UI>();

		this.StartGame();
	}


	/**
	 * Returns a spawn position on a circle with the given radius
	 */
	private Vector3 GetSpawnPosition(float angle, float radius)
	{
		Vector3 position;
		position.x = Config.screenCenter.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
		position.y = Config.screenCenter.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
		position.z = Config.screenCenter.z;

		// TODO: Make sure that the spawn position is unique and no other game object / enemy is already there

		return position;
	}
	
	
	/**
	 * Starts the game
	 */
	public void StartGame()
	{
		Game.SetScore(0);

		this.player.Activate();
		this.SpawnNewEnemies();
	}


	/**
	 * Spawns new enemies
	 */
	public void SpawnNewEnemies()
	{
		var activeEnemyObjects	= this.enemyObjectPool.GetActiveObjectPoolEntityAmount() + this.enemyMissileObjectPool.GetActiveObjectPoolEntityAmount();
		var maxNewEnemies		= this.maxEnemyObjects - activeEnemyObjects;
		var spawnChance			= 1f - ((float) activeEnemyObjects / (float) this.maxEnemyObjects);
		
		if (Random.value <= spawnChance)
		{
			var radius = Random.Range(1, 5); // player radius is 5 so the max radius for enemies can be 4
			var amount = Random.Range(1, Mathf.Min(this.maxEnemySwarmSize, maxNewEnemies));
			
			for (int index = 1; index <= amount; index ++)
			{
				var enemy = this.enemyObjectPool.GetObjectPoolEntity();
				enemy.Activate(this.GetSpawnPosition((this.distanceWithinEnemySwarms * index) / radius, radius));
			}
		}

		// Respawn new enemies from time to time
		this.Invoke("SpawnNewEnemies", 1f);
	}

	

	/**
	 * Adds the given amount to the total score
	 */
	public static void AddScore(int score)
	{
		Game.SetScore(Game.totalScore + score);
	}


	/**
	 * Sets the score to the given amount
	 */
	private static void SetScore(int score)
	{
		Game.totalScore			= score;
		Game.ui.totalScore.text	= Game.totalScore.ToString();
	}


	/**
	 * Sets the lifes ui text
	 */
	public static void SetLifesUI(int lifes)
	{
		Game.ui.lifeAmount.text	= lifes.ToString();
	}
}
