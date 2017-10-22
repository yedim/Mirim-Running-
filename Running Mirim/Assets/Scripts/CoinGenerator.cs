using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    //젤리 생성을 위한 부모 오브젝트
    public GameObject CoinParent;
    public ObjectPooler coinPool;

    public float distanceBetweenCoins;
    
    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x-distanceBetweenCoins,startPosition.y,startPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObject();
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
        coin3.SetActive(true);

        coin1.transform.parent = CoinParent.transform; //부모로 지정
        coin2.transform.parent = CoinParent.transform; 
        coin3.transform.parent = CoinParent.transform; 
    }

    public void RemoveAllCoin()
    {
        while(CoinParent.transform.childCount != 0)
        {
            GameObject Child = CoinParent.transform.GetChild(0).gameObject;
            Child.SetActive(false);
            Child.transform.parent = null;
        }        
    }
}
