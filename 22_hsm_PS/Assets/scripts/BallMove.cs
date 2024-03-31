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
                // 충돌한 물체가 플레이어일 때, 현재 오브젝트를 파괴
                gameObject.SetActive(false);
                Play.Instance.objectStack.Push(gameObject);
                break; // 더 이상 검사하지 않음
            }
        }
    }

}
