using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float spawnRate = 2f;
    public float heightOffset = 1f;
    public float minY = -1f;
    public float maxY = 2f;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        timer += Time.deltaTime;
        if(timer >= spawnRate)
        {
            timer = 0f;
            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        GameObject pipe = PipePool.Instance.GetPooledObject();
        if (pipe != null)
        {
            float y = Random.Range(minY, maxY);
            Vector3 spawnPos = new Vector3(transform.position.x, y, -1f);

            pipe.transform.position = spawnPos;
            pipe.transform.rotation = Quaternion.identity;
            pipe.SetActive(true);
        }
    }
}
