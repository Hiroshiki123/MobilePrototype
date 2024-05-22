using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Note prefab;

    void Start()
    {
        StartCoroutine(SpawnSphere());
    }

    IEnumerator SpawnSphere() 
    {
        var note = Instantiate(prefab,transform.position,transform.rotation);
        var color = (PlayerColor)Random.Range(0, 3);
        print(color);
		note.ColorChange(color);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpawnSphere());
    }

}
