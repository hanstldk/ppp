using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaticMeshGen))]
public class StaticMeshGenEditor : Editor
{
    //��ư����� ����
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        StaticMeshGen script = (StaticMeshGen)target;

        if (GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }

    }
}

//�޽������ ����
public class StaticMeshGen : MonoBehaviour
{
    public Shader shader;
    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3 (0, 5f, 0.0f),
            new Vector3 (0.951f, 2.618f, 0.0f),
            new Vector3 (3.090f, 2.618f, 0.0f),
            new Vector3 (1.902f, 0.618f, 0.0f),
            new Vector3 (2.853f, -1.618f, 0.0f),
            new Vector3 (0, -0.5f, 0.0f),
            new Vector3 (-2.853f, -1.618f, 0.0f),
            new Vector3 (-1.902f, 0.618f,0),
            new Vector3 (-3.090f, 2.618f, 0.0f),
            new Vector3 (-0.951f, 2.618f, 0.0f),




            new Vector3 (0, 5f, 4.0f),
            new Vector3 (0.951f, 2.618f, 4.0f),
            new Vector3 (3.090f, 2.618f, 4.0f),
            new Vector3 (1.902f, 0.618f, 4.0f),
            new Vector3 (2.853f, -1.618f, 4.0f),
            new Vector3 (0, -0.5f, 4.0f),
            new Vector3 (-2.853f, -1.618f, 4.0f),
            new Vector3 (-1.902f, 0.618f,4f),
            new Vector3 (-3.090f, 2.618f, 4.0f),
            new Vector3 (-0.951f, 2.618f, 4.0f),
        };

        mesh.vertices = vertices;

        int[] triangleIndices = new int[]
        {
            0, 1, 9,   // ù ��° �ﰢ��
            1, 2, 3,   // �� ��° �ﰢ��
            3, 4, 5,   // �� ��° �ﰢ��
            5, 6, 7,   // �� ��° �ﰢ��
            7, 8, 9,   // �ټ� ��° �ﰢ��
            9, 1, 3,   // ���� ��° �ﰢ��
            7, 3, 5,   // �ϰ� ��° �ﰢ��
            9, 3, 7,

            10,19,11,
            19,18,17,
            17,16,15,
            15,14,13,
            13,12,11,
            19,17,13,
            11,19,13,
            17,15,13,

            0,9,19,
            0,19,10,

            9,8,18,
            9,18,19,

            8,7,17,
            8,17,18,

            7,6,16,
            7,16,17,

            6,5,15,
            6,15,16,

            5,4,14,
            5,14,15,

            4,3,13,
            4,13,14,

            3,2,12,
            3,12,13,

            2,1,11,
            2,11,12,

            1,0,10,
            1,10,11,
            
        };

        mesh.triangles = triangleIndices;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
    }

    private void Start()
    {
        // Material�� ����ϴ�.
        Material material = new Material(shader);

        // Material�� MeshRenderer�� �Ҵ��մϴ�.
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
    }
}
