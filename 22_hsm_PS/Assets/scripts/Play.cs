using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public static Play Instance;
    public GameObject prefab; // ������ ������
    public Material[] materials;
    public StackWithTwoQueues<GameObject> objectStack;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // �ߺ��Ǵ� �ν��Ͻ� ����
            return;
        }

        objectStack = new StackWithTwoQueues<GameObject>();

        // �ʱ⿡ 10���� ���� ������Ʈ�� �����Ͽ� ť�� ����
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
            obj.GetComponent<Renderer>().material = materials[i];
            obj.SetActive(false);
            objectStack.Push(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ť���� ������Ʈ�� �����ͼ� Ȱ��ȭ
            if (!objectStack.IsEmpty())
            {
                GameObject obj = objectStack.Pop();
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
