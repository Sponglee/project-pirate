using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEnemySpawner : MonoBehaviour
{
    public GameObject dummyPref;
    public Transform[] spawnPoints;
    public List<TargetDummy> enemies = new List<TargetDummy>();

    private void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            SpawnEnemy(i);
        }
    }

    public void SpawnEnemy(int index)
    {
        TargetDummy tmpDummy = Instantiate(dummyPref, spawnPoints[index].position, Quaternion.identity)
            .GetComponent<TargetDummy>();
        enemies.Add(tmpDummy);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Gizmos.DrawSphere(spawnPoints[i].position, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].Engage();
        }
    }
}