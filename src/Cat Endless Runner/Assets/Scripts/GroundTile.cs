using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(Random.Range(0, 4));
        Destroy(gameObject, 2);
    }
    
    void Update()
    {
        
    }

	[SerializeField] private GameObject birdPrefab;

	public void SpawnBirds()
	{
		int obstacleSpawnIndex = Random.Range(2, 5);
    	Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
    	Vector3 spawnPosition = spawnPoint.position - new Vector3(0f, -1.3f, 0f);
    	Quaternion spawnRotation = Quaternion.Euler(0f, 180f, 0f); 

    	GameObject go = Instantiate(birdPrefab, spawnPosition, spawnRotation, transform) as GameObject;
    	go.AddComponent<Birds>();
	}	

	[SerializeField] private GameObject dogPrefab;

	public void SpawnDogs()
	{
		int obstacleSpawnIndex = Random.Range(2, 5);
    	Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
    	Vector3 spawnPosition = spawnPoint.position - new Vector3(0f, 0.5f, 0f);
    	Quaternion spawnRotation = Quaternion.Euler(0f, 180f, 0f); 

    	GameObject go = Instantiate(dogPrefab, spawnPosition, spawnRotation, transform) as GameObject;
    	go.AddComponent<Dogs>();
	}	


	[SerializeField] private GameObject obstaclePrefab1;
	[SerializeField] private GameObject obstaclePrefab2;
	[SerializeField] private GameObject obstaclePrefab3;
	[SerializeField] private GameObject obstaclePrefab4;
	[SerializeField] private GameObject obstaclePrefab5;
	[SerializeField] private GameObject obstaclePrefab6;
	[SerializeField] private GameObject obstaclePrefab7;

	public void SpawnFlowers()
	{
    	int obstacleIndex = Random.Range(0, 7);

    	GameObject obstaclePrefab = null;
   		switch (obstacleIndex)
    	{
      		case 0:
            	obstaclePrefab = obstaclePrefab1;
            	break;
        	case 1:
            	obstaclePrefab = obstaclePrefab2;
            	break;
        	case 2:
            	obstaclePrefab = obstaclePrefab3;
            	break;
        	case 3:
            	obstaclePrefab = obstaclePrefab4;
            	break;
        	case 4:
            	obstaclePrefab = obstaclePrefab5;
            	break;
        	case 5:
            	obstaclePrefab = obstaclePrefab6;
            	break;
        	case 6:
            	obstaclePrefab = obstaclePrefab7;
            	break;
        	default:
            	Debug.LogError("Invalid obstacle index!");
            	break;
   		}

    	if (obstaclePrefab != null)
    	{
        	int obstacleSpawnIndex = Random.Range(2, 5);
        	Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        	GameObject go = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform) as GameObject;
			go.AddComponent<Flowers>();

			BoxCollider boxCollider = go.AddComponent<BoxCollider>();
			boxCollider.size = new Vector3(1, 1, 1);
    	}
	}

	[SerializeField] private GameObject coinPrefab;

	public void SpawnCoins() 
	{
		int coinsToSpawn = 2;
		for (int i = 0; i < coinsToSpawn; ++i)
		{
			GameObject temp = Instantiate(coinPrefab, transform);
			Collider collider = temp.AddComponent<BoxCollider>();
			collider.isTrigger = true;
			temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
		}
	}

	[SerializeField] private GameObject boostPrefab;

	public void SpawnBoost() 
	{
		int toSpawn = Random.Range(0, 10);
		if (toSpawn == 4)
		{
			GameObject temp = Instantiate(boostPrefab, transform);
			Collider collider = temp.AddComponent<BoxCollider>();
			collider.isTrigger = true;
			temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
		}
	}
	
	Vector3 GetRandomPointInCollider(Collider collider) 
	{
		Vector3 point = new Vector3(
			Random.Range(collider.bounds.min.x, collider.bounds.max.x),
			Random.Range(collider.bounds.min.y, collider.bounds.max.y),
			Random.Range(collider.bounds.min.z, collider.bounds.max.z));
		if (point != collider.ClosestPoint(point))
		{
			point = GetRandomPointInCollider(collider);
		}
		point.y = 1;
		return point;
 	}
}

