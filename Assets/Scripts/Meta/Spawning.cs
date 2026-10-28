using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class Spawning : MonoBehaviour
{
    private bool running = false;
    [SerializeField] private float spawnRange = 50f, spawnLimit = 45.0f;
    [SerializeField] private GameObject gameobject;
    public static List<GameObject> objectsList = new List<GameObject>();
    [SerializeField] private List<Transform> spawnList = new List<Transform>();
// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Object[] subListObjects = Resources.LoadAll("Prefabs", typeof(GameObject));
        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;
            objectsList.Add(lo);
        }
    }

    void Update()
    {
        if (!running) 
        {
            running = true;
            StartCoroutine(SpawnObstacle());
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (running)
        {
            if (Stats.health == 0) { running = false;  yield break; }
            yield return new WaitForSeconds(0.2f);
            spawnRange = Random.Range(-spawnLimit, spawnLimit);
            GameObject _newSpawn = Instantiate(objectsList[Random.Range(0, objectsList.Count)]) as GameObject;
            var _location = spawnList[Random.Range(0, spawnList.Count)];
            _newSpawn.transform.position = new Vector3(_location.position.x, _location.position.y + 100f, _location.position.z);
        }
    }
}
