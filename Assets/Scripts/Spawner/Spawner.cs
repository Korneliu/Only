using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private float _delay = 3F;
    private Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnCD());
    }


    private IEnumerator SpawnCD()
    {
        while (true)
        {
            foreach (var spawnPo in spawnPos)
            {
                var position = new Vector3(spawnPo.position.x, spawnPo.position.y, _player.position.z);
                Instantiate(enemy, position, Quaternion.identity);
            }

            yield return new WaitForSeconds(_delay);
        }
    }
}