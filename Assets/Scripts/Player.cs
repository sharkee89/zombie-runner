using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Transform playerSpawnPoints; // parent of the spawn points
    public bool reSpawn = false;
    public Helicopter helicopter;

    private Transform[] spawnPoints;
    private bool lastToggle = false;
    
    // Use this for initialization
	void Start () {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
        print(spawnPoints.Length);
	}
	
	// Update is called once per frame
	void Update () {
	    if (lastToggle != reSpawn) {
            Respawn();
            reSpawn = false;
        } else {
            lastToggle = reSpawn;
        }
	}

    private void Respawn() {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
    }

    void onFindClearArea () {
        Debug.Log("Found clear area from PLAYER!");
        helicopter.Call();
    }
}
