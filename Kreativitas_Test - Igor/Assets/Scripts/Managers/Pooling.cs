using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int poolAmount;

    public List<GameObject> pools = new List<GameObject>();

    //private Projectile projectile;

    private void Start() {
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pools.Add(obj);
        }
    }

    public void SpawnAll(Transform spawnPoint)
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

    public void SpawnOne(Transform spawnPoint)
    {
        pools[0].transform.position = spawnPoint.position;
        pools[0].SetActive(true);

        pools[0].GetComponent<Projectile>().SetPooling(this);

        pools.Remove(pools[0]);
    }

    public void Enqueue(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = Vector3.zero;
        pools.Add(obj);
    }
}
