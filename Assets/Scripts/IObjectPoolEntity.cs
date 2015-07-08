using UnityEngine;

/**
 * An object pool entity interface which forces any pooled object to implement the needed functionality
 */
public interface IObjectPoolEntity
{
	/**
	 * Activates the object pool entity
	 */
	void Activate(Vector3 spawnPosition);

	/**
	 * Deactivates the object pool entity
	 */
	void Deactivate();

	/**
	 * Returns true if the object pool entity is active
	 */
	bool IsActive();
}
