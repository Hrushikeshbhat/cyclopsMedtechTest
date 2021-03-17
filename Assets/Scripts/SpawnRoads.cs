using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnRoads : MonoBehaviour
{

    public GameObject[] roads;
    public GameObject player;
    int numberofTiles = 5;
    int lengthofTile = 10;
    float dir = 0;
    List<GameObject> tiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberofTiles; i++)
        {
            if (i == 0)
                generateRoads(0);
            generateRoads(Random.Range(0, roads.Length));
        }
    }

    private void Update()
    {
        if (player.transform.position.x > (dir - (numberofTiles * lengthofTile)) + 20)
        {
            generateRoads(Random.Range(0, roads.Length));
            Destroy(tiles[0]);
            tiles.RemoveAt(0);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }



    void generateRoads(int index)
    {
        GameObject go = Instantiate(roads[index], transform.right * dir, Quaternion.Euler(0, 0, 0));
        tiles.Add(go);
        dir += 10;
    }

}
