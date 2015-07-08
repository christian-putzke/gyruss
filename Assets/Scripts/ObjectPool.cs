using UnityEngine;
using System.Collections.Generic;

/**
 * The object pool class handles the object pool of the the given prefab
 */
public class ObjectPool : MonoBehaviour
{
	/**
	 * The prefab which will be pooled
	 */
	public GameObject prefab;


	/**
	 * The spawn container where the prefabs will be spawned or activated
	 */
	public Transform spawnContainer;


	/**
	 * The pre pool amount will instantiate automatically the given amount of prefabs within the object pool
	 */
	public int prePoolAmount = 10;


	/**
	 * The pooled objects
	 */
	private List<IObjectPoolEntity> objectPool = new List<IObjectPoolEntity>();



	/**
	 * Pool the prePoolAmount of prefabs into the object pool
	 */
	private void Start()
	{
		for(var index = 0; index < this.prePoolAmount; index ++)
		{
			this.AddObjectPoolEntity().Deactivate();
		}
	}


	/**
	 * Returns a "free" object pool entity
	 * Creates new object pool entities on the fly
	 */
	public IObjectPoolEntity GetObjectPoolEntity()
	{
		for (var index = 0; index < this.objectPool.Count; index ++)
		{
			if (!this.objectPool[index].IsActive())
			{
				return this.objectPool[index];
			}
		}
		
		return this.AddObjectPoolEntity();
	}


	/**
	 * Returns the amount if active object pool entities
	 */
	public int GetActiveObjectPoolEntityAmount()
	{
		var activeObjectPoolEntityAmount = 0;

		for (var index = 0; index < this.objectPool.Count; index ++)
		{
			if (this.objectPool[index].IsActive())
			{
				activeObjectPoolEntityAmount ++;
			}
		}
		
		return activeObjectPoolEntityAmount;
	}


	/**
	 * Adds a new object pool entity to the object pool and returns it
	 */
	private IObjectPoolEntity AddObjectPoolEntity()
	{
		var pooledGameObject	= this.Instantiate(this.prefab) as GameObject;
		pooledGameObject.name	= this.prefab.name;
		var objectPoolEntity	= pooledGameObject.GetComponent<IObjectPoolEntity>();

		if (objectPoolEntity == null)
		{
			throw new UnityException("You can't pool objects which does not implement IObjectPoolEntity!");
		}

		pooledGameObject.transform.SetParent(this.spawnContainer, false);
		
		this.objectPool.Add(objectPoolEntity);
		
		return objectPoolEntity;
	}
}
