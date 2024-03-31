using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.01f, 0, 0));


        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.5f, 0.5f));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Goal"))
            {
                // �浹�� ��ü�� �÷��̾��� ��, ���� ������Ʈ�� �ı�
                gameObject.SetActive(false);
                Play.Instance.objectStack.Push(gameObject);
                break; // �� �̻� �˻����� ����
            }
        }
    }

}
