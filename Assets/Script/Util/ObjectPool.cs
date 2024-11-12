using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : Singleton<ObjectPool>
{

    [System.Serializable]
    public class PoolInfo
    {

        public string Name;
        public GameObject prefab;
        public int size;

    }

    [SerializeField]
    private PoolInfo[] poolInfo;

    private string objectName;

    // 오브젝트풀들을 관리할 딕셔너리
    private Dictionary<string, IObjectPool<GameObject>>
    ojbectPoolDic = new Dictionary<string, IObjectPool<GameObject>>();

    // 오브젝트풀에서 오브젝트를 새로 생성할때 사용할 딕셔너리
    private Dictionary<string, GameObject> poolGoDic = new Dictionary<string, GameObject>();

    private void Init()
    {
        for (int idx = 0; idx < poolInfo.Length; idx++)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
            OnDestroyPoolObject, true, poolInfo[idx].size, poolInfo[idx].size);

            if (poolGoDic.ContainsKey(poolInfo[idx].Name))
            {
                Debug.LogFormat("{0} 이미 등록된 오브젝트입니다.", poolInfo[idx].Name);
                return;
            }

            poolGoDic.Add(poolInfo[idx].Name, poolInfo[idx].prefab);
            ojbectPoolDic.Add(poolInfo[idx].Name, pool);

            // 미리 오브젝트 생성 해놓기
            for (int i = 0; i < poolInfo[idx].size; i++)
            {
                objectName = poolInfo[idx].Name;
                PoolAble poolAbleGo = CreatePooledItem().GetComponent<PoolAble>();
                poolAbleGo.Pool.Release(poolAbleGo.gameObject);
            }
        }


    }


    private GameObject CreatePooledItem()
    {

        GameObject poolGo = Instantiate(poolGoDic[objectName]);
        poolGo.GetComponent<PoolAble>().Pool = ojbectPoolDic[objectName];
        return poolGo;
    }

    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);

    }

    private void OnReturnedToPool(GameObject poolGo) 
    {

        poolGo.SetActive(false);

    }

    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }

    public GameObject GetGo(string goName)
    {
        objectName = goName;

        if (poolGoDic.ContainsKey(goName) == false)
        {
            Debug.LogFormat("{0} 오브젝트풀에 등록되지 않은 오브젝트입니다.", goName);
            return null;
        }

        return ojbectPoolDic[goName].Get();
    }
}
