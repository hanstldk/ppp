using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static queue;

public class Play : MonoBehaviour
{
    public static Play Instance;
    public GameObject prefab; // 재사용할 프리팹
    public Material[] materials;
    public LinkedListQueue<GameObject> objectQueue;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복되는 인스턴스 제거
            return;
        }

        objectQueue = new LinkedListQueue<GameObject>();

        // 초기에 10개의 게임 오브젝트를 생성하여 큐에 넣음
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
            obj.GetComponent<Renderer>().material = materials[i];
            obj.SetActive(false);
            objectQueue.Enqueue(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 큐에서 오브젝트를 가져와서 활성화
            if (!objectQueue.IsEmpty())
            {
                GameObject obj = objectQueue.Dequeue();
                obj.transform.position = new Vector3(-8,1,0);
                obj.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Object pool is empty.");
            }
        }
    }
}
