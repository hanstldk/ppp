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
    public Material material;
    private Mesh mesh;
    public void GenerateMesh()
    {
        mesh = new Mesh();

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




        Vector3[] normals = new Vector3[vertices.Length];

        mesh.triangles = triangleIndices;


        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            int index1 = mesh.triangles[i];
            int index2 = mesh.triangles[i + 1];
            int index3 = mesh.triangles[i + 2];

            Vector3 v1 = vertices[index1];
            Vector3 v2 = vertices[index2];
            Vector3 v3 = vertices[index3];

            // �ﰢ���� �̷�� �� ������ �̿��Ͽ� �ﰢ���� �븻 ���͸� ����մϴ�.
            Vector3 normal = Vector3.Cross(v2 - v1, v3 - v1).normalized;

            // �� ������ �븻 ���Ϳ� �ﰢ���� �븻 ���͸� ���մϴ�.
            normals[index1] += normal;
            normals[index2] += normal;
            normals[index3] += normal;
        }

        // �� ������ �븻 ���͸� ����ȭ�մϴ�.
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = normals[i].normalized;
        }

        // ����� ����մϴ�.
        for (int i = 0; i < normals.Length; i++)
        {
            Debug.Log("Vertex: " + vertices[i] + ", Normal: " + normals[i]);
        }

        mesh.normals = normals;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
        mr.material= material;
    }

    private void Start()
    {
        // Material�� MeshRenderer�� �Ҵ��մϴ�.
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        


        
    }

}
