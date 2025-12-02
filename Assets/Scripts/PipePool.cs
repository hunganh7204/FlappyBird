using UnityEngine;
using System.Collections.Generic;

public class PipePool : MonoBehaviour
{
    public static PipePool Instance;
    public List<GameObject> pooledPipes;
    public GameObject pipeToPool;
    public int amountToPool;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pooledPipes = new List<GameObject>();
        GameObject pipe;
        for(int i = 0;i<amountToPool;i++)
        {
            pipe = Instantiate(pipeToPool);
            pipe.SetActive(false);
            pooledPipes.Add(pipe);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i<pooledPipes.Count;i++)
        {
            if (!pooledPipes[i].activeInHierarchy)
            {
                return pooledPipes[i];
            }
        }

        return null;
    }


}
