using UnityEngine;
using System.Collections;

public class SnowSpawn : MonoBehaviour {
		public Rigidbody2D backgroundProp;		// The prop to be instantiated.
		public float upSpawnPosY;				// The Y coordinate of position if it's instantiated on the left.
		public float downSpawnPosY;			// The Y coordinate of position if it's instantiated on the right.
		public float leftSpawnPosX;				// The lowest possible X coordinate of position.
		public float rightSpawnPosX;				// The highest possible X coordinate of position.
		public float minTimeBetweenSpawns;		// The shortest possible time between spawns.
		public float maxTimeBetweenSpawns;		// The longest possible time between spawns.
		public float minSpeed;					// The lowest possible speed of the prop.
		public float maxSpeed;					// The highest possible speeed of the prop.
		
		void Start ()
		{
			StartCoroutine("Snow");
		}
		
		IEnumerator Snow ()
		{
			float waitTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
			yield return new WaitForSeconds(waitTime);
			float posX =Random.Range(leftSpawnPosX, rightSpawnPosX);
			float posY = upSpawnPosY;
			Vector3 spawnPos = new Vector3(posX , posY,transform.position.z );
			Rigidbody2D propInstance = Instantiate(backgroundProp, spawnPos, Quaternion.identity) as Rigidbody2D;
			Vector3 scale = propInstance.transform.localScale;
			scale.y *= -1;
			propInstance.transform.localScale = scale;
			float speed = Random.Range(minSpeed, maxSpeed);
			speed *= -1f;
			propInstance.velocity = new Vector2(0,speed);
			StartCoroutine(Snow());
			
			while(propInstance != null)
			{
				if(propInstance.transform.position.y < downSpawnPosY - 0.5f)
					Destroy(propInstance.gameObject);
				yield return null;
			}
		}
	}
