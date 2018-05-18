using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Transform BackgroundPrefab;

    public Transform EnemyPrefab;

    // Use this for initialization
    void Start ()
    {

        GenerateBackground();
        GenerateEnemies();
	}
	
    void GenerateBackground()
    {
        float Backgroundwidth = BackgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        for(float x = 0; x < 3 * Backgroundwidth; x += Backgroundwidth)
        {
            Instantiate(BackgroundPrefab, new Vector3(x, 0, 100), Quaternion.identity);
        }
    }

    void GenerateEnemies()
    {
        Instantiate(EnemyPrefab, new Vector3(10, 0, 1), Quaternion.identity);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
