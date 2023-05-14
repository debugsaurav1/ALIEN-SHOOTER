using UnityEngine;

public class MoveSpawnPoint : MonoBehaviour
{
    public GameObject  asteroid;
    public Transform spawnPoint;
	int direction = -1;
	float speed = 0.005f;
    float timer = 0f;

    private int count;
	// Start is called before the first frame update
	void Start()
    {
	    count = 0;
	}

    // Update is called once per frame
    void Update()
    {
      
        transform.Translate(0, direction * speed, 0);

        if (transform.position.y <=-4.0f)
        {
            direction = 1;
        }
        else if (transform.position.y >= 4.0f)
        {
            direction = -1;
        }
        InstanciateAstroid();
	}
    private void InstanciateAstroid()
    {
        int count = asteroidCounter();
        timer += Time.deltaTime;
        if (timer > 2.0f && count <= 15)
        {
            Instantiate(asteroid, spawnPoint.position, Quaternion.identity);
            timer = 0f;
        }
    }
    private int asteroidCounter()
    {
       
       GameObject[] astroidCount = GameObject.FindGameObjectsWithTag("Astroid");
       count = astroidCount.Length;  
       return count;
    }
}
