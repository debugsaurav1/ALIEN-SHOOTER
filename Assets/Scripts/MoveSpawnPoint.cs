using UnityEngine;

public class MoveSpawnPoint : MonoBehaviour
{
    public GameObject  asteroid;
    public Transform spawnPoint;
	public Boundry boundary;
	int direction = -1;
	float speed = 0.005f;
    float timer = 0f;

    private int count;
	// Start is called before the first frame update
	void Start()
    {
        
		if (!boundary)
		{
			boundary = Camera.main.GetComponent<Boundry>();
		}
		count = 0;
        setToRightEdge();
		setToTopEdge();
		//Vector3 newPosition = transform.position;
		//newPosition.x = boundary.rightEdgeValue;
		//     // newPosition.y = boundary.topEdgeValue;
		//transform.position = newPosition;
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 newPosition = setToTopEdge();

		transform.Translate(0, direction * speed, 0);
		
        if (transform.position.y <=-newPosition.y)
        {
            direction = 1;
        }
        else if (transform.position.y >= newPosition.y)
        {
            direction = -1;
        }
        InstanciateAstroid();
		//setToEdge();

	}
	private void InstanciateAstroid()
    {
		//float randomFloat = Random.Range(0.0f, 5.0f);
		int count = asteroidCounter();
        timer += Time.deltaTime;
        if (timer > 3.0f && count <= 35)
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
	void setToRightEdge()
	{
	    if (!spawnPoint)
		    {
			    Debug.Log("Spawn point not set");
			    return;
		    }
        Debug.Log(boundary.GetScreenRightEdge());
		Vector3 newPosition = spawnPoint.position;
	    newPosition.x = boundary.GetScreenRightEdge();
		spawnPoint.position = newPosition;
        print(newPosition);
	}
	private Vector3 setToTopEdge()
	{
		if (!spawnPoint)
		{
			Debug.Log("Spawn point not set");
		}
		Debug.Log(boundary.GetScreenTopEdge());
		Vector3 newPosition = spawnPoint.position;
		newPosition.y = boundary.GetScreenTopEdge();
		return newPosition;
		//spawnPoint.position = newPosition;
		//print(newPosition);
	}
}
