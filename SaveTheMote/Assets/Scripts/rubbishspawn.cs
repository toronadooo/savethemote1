using UnityEngine;
using System.Collections;

public class RubbishSpawn : MonoBehaviour
{
	public Rigidbody2D rubbishprop;		// The prop to be instantiated.
	public float leftSpawnPosX;				// The x coordinate of position if it's instantiated on the left.
	public float rightSpawnPosX;			// The x coordinate of position if it's instantiated on the right.
	public float minSpawnPosY;				// The lowest possible y coordinate of position.
	public float maxSpawnPosY;				// The highest possible y coordinate of position.
	public float minTimeBetweenSpawns;		// The shortest possible time between spawns.
	public float maxTimeBetweenSpawns;		// The longest possible time between spawns.
	public float minSpeed;					// The lowest possible speed of the prop.
	public float maxSpeed;					// The highest possible speeed of the prop.
	public bool proper=false;
	void Start ()
	{
		StartCoroutine("Spawn");
	}


	IEnumerator Spawn ()
	{
		float waitTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
		yield return new WaitForSeconds(waitTime);
		float posX = rightSpawnPosX;
		float posY = Random.Range(minSpawnPosY, maxSpawnPosY);
		Vector3 spawnPos = new Vector3(posX, posY, transform.position.z);
		Rigidbody2D propInstance = Instantiate(rubbishprop, spawnPos, Quaternion.identity) as Rigidbody2D;
		Vector3 scale = propInstance.transform.localScale;
		scale.x *= -1;
		propInstance.transform.localScale = scale;
		float speed = Random.Range(minSpeed, maxSpeed);
		speed *= -1f;
		propInstance.velocity = new Vector2(speed, 0);
		StartCoroutine(Spawn());

			while(propInstance != null)
		{
			if((propInstance.transform.position.x < leftSpawnPosX - 0.5f))
					Destroy(propInstance.gameObject);
						yield return null;
		}
	}
}
