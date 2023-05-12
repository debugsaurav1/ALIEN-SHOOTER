using UnityEngine;

public class Bullet : MonoBehaviour
{
	public static Bullet instance;
	public float bulletSpeed = 2f;
	public float destroyTime = 2.5f;
	public int damageAmount = 10;
	public GameObject explosion;
	private int hitCount = 0;
	

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		Destroy(gameObject, destroyTime);
	}

	private void Update()
	{
		float distance = bulletSpeed * Time.deltaTime; // distance to move this frame
		Vector3 movement = new Vector3(distance, 0f, 0f); // movement vector
		transform.Translate(movement); // move the object
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("destroyer"))
		{
			Destroy(gameObject);
		}

		if (collision.gameObject.CompareTag("Astroid"))
		{
			Destroy(gameObject); // Destroy the bullet
			Destroy(collision.gameObject); // destroy the asteroid
			GetHitCount();
			Instantiate(explosion, transform.position, Quaternion.identity);
		}
	}


	public int GetHitCount()
	{
		hitCount++;
		UIManager.instance.UpdateScoreText(hitCount);
		return hitCount;
	}
}
