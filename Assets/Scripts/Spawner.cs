using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] tetrominoes;
   
    // Start is called before the first frame update
    void Start()
    {
        NewTetrominoe(Random.Range(0,tetrominoes.Length));
    }

    public void NewTetrominoe(int y)
    {
        Instantiate(tetrominoes[y], transform.position, Quaternion.identity);

    }
}
