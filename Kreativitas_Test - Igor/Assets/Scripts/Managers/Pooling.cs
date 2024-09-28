using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int poolAmount;

    public List<GameObject> pools = new List<GameObject>();

    private void Start() {
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pools.Add(obj);
        }
    }

    public void Spawn(Transform spawnPoint)
    {
        for (int i = 0; i < pools.Count; i++)
        {
            if(!pools[i].activeInHierarchy)
            {
                pools[i].transform.position = spawnPoint.position;
                pools[i].SetActive(true);
                break;
            }
        }
    }
}
