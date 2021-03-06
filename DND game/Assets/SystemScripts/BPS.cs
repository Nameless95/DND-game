using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BPS : MonoBehaviour
{
    public static BPS instance;

    List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] List<PoolItem> itemsToPool = null;

    private void Awake(){
        instance = this;
    }

    private void Start(){
        pooledObjects = new List<GameObject>();
    }

    public GameObject GetPooledObject(string tag){
        foreach(GameObject pooledObject in pooledObjects){
            if(!pooledObject.activeSelf && pooledObject.CompareTag(tag)){
                return pooledObject;
            }
        }

        foreach(PoolItem item in itemsToPool){
            if(item.id.Equals(tag)){
                GameObject obj = Instantiate(item.poolObject);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        Debug.Log("returned a null, " + tag + " does not exist");
        return null;
    }
}

[System.Serializable]
public class PoolItem{
    public string id;
    public GameObject poolObject;

    public PoolItem(string tag, GameObject poolingObject) {
        id = tag;
        poolObject = poolingObject;
    }
}
