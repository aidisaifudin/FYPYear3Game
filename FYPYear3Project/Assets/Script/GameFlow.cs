using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform tile1Obj;
    private Vector3 nextTileSpawn;
    public Transform bricksObj;
    private Vector3 nextBrickSpawn;
    private int randX;

    // Start is called before the first frame update
    void Start()
    {
        nextTileSpawn.z = 18;
        StartCoroutine(spawnTile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        randX = Random.Range(-1, 2);
        nextBrickSpawn = nextTileSpawn;
        nextBrickSpawn.y = .16f;
        nextBrickSpawn.x = randX;
        Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation);
        Instantiate(tile1Obj, nextBrickSpawn, bricksObj.rotation);
        nextTileSpawn.z += 3;
        Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation);
        nextTileSpawn.z += 3;
        StartCoroutine(spawnTile());
    }
}
