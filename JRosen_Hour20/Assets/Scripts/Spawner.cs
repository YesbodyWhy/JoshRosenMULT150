using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject obstaclePrefab;
    public float spawnCycle = 0.5f;
    public int RepeatCounter = 0;
    public bool LastSpawned;

    GameManager manager;
    float elapsedTime;
    bool spawnPowerup = true;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > spawnCycle)
        {

            int Count = 0;

            while (Count < Random.Range(1, 3))
            {
                spawnPowerup = !spawnPowerup;
                Count += 1;
            }

            if (spawnPowerup == LastSpawned)
            {
                RepeatCounter += 1;
                if (RepeatCounter > 12) {
                    RepeatCounter = 0;
                    spawnPowerup = !spawnPowerup;
                }
            }
            else
            {
                RepeatCounter = 0;
            }

            GameObject temp;
            if (spawnPowerup)
            {
                temp = Instantiate(powerupPrefab) as GameObject;
            }
            else
            {
                temp = Instantiate(obstaclePrefab) as GameObject;
            }

            Vector3 position = temp.transform.position;
            position.x = Random.Range(-3f, 3f);
            temp.transform.position = position;
            

            Collidable col = temp.GetComponent<Collidable>();
            col.manager = manager;

            elapsedTime = 0;
            spawnPowerup = !spawnPowerup;
            spawnCycle = Mathf.Clamp(spawnCycle + Random.Range(-0.05f, 0.05f), 0.2f, 0.7f);

        }

        manager.IncreaseDifficulty(Mathf.Floor((elapsedTime % 10f) / 1000f));

    }
}
