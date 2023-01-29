using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemyController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new();
    [SerializeField] private List<Transform> spawnPositions = new();
    [SerializeField] private Transform enemyParent;
    [SerializeField] private float timeToRespEnemy = 2;
    [SerializeField] private int minEnemiesRespawn = 2;
    [SerializeField] private int maxEnemiesRespawn = 5;

    private WaitForSeconds _waitForNextResp;
    private List<Transform> _runtimeSpawnPositions = new();

    private void Awake()
    {
        _waitForNextResp = new WaitForSeconds(timeToRespEnemy);
    }

    private void Start()
    {
        StartCoroutine(StartResp());
    }

    private IEnumerator StartResp()
    {
        var enemiesCount = Random.Range(minEnemiesRespawn, maxEnemiesRespawn);
        _runtimeSpawnPositions.AddRange(spawnPositions);

        for (int i = 0; i < enemiesCount; i++)
        {
            var obiectToResp = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            var respPos = _runtimeSpawnPositions[Random.Range(0, _runtimeSpawnPositions.Count)];

            var enemy = Instantiate(obiectToResp, respPos.position, Quaternion.identity);
            enemy.transform.parent = enemyParent;

            _runtimeSpawnPositions.Remove(respPos);
        }

        _runtimeSpawnPositions.Clear();

        yield return _waitForNextResp;

        StartCoroutine(StartResp());
    }
}
