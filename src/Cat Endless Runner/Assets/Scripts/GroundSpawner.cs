using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject groundTile;
    private Vector3 nextSpawnPoint;

    public void SpawnTile(int spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
		
		if (spawnItems > 0)
		{
			switch (spawnItems % 3)
			{
				case 0:
				{
					temp.GetComponent<GroundTile>().SpawnFlowers();
					break;
				}
				case 1:
				{
					temp.GetComponent<GroundTile>().SpawnDogs();
					break;
				}
				default:
				{
					temp.GetComponent<GroundTile>().SpawnBirds();
					break;
				}
			}
		}
		temp.GetComponent<GroundTile>().SpawnCoins();
        temp.GetComponent<GroundTile>().SpawnBoost();
    }

    void Start()
    {
        for (int i = 0; i < 30; ++i) 
		{
        	if (i < 3)
				SpawnTile(0);
            else
				SpawnTile(i);
        }
    }
}
