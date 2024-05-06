using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapGenerator : MonoBehaviour
{
    public GameObject lowWall;
    public GameObject highWall;
    public GameObject terrain;
    public int sizeW = 30;
    public int sizeH = 30;

    void Start()
    {
        GenerateMapFromCSV("Assets/Midterm/Map.csv");
    }

    void GenerateMapFromCSV(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        int width = lines[0].Split(',').Length;
        int height = lines.Length;
        float startPosX = -terrain.transform.localScale.x * 5;  // 시작 위치 X
        float startPosZ = terrain.transform.localScale.z * 5;   // 시작 위치 Z

        for (int y = 0; y < height; y++)
        {
            string[] line = lines[y].Split(',');
            for (int x = 0; x < width; x++)
            {
                GameObject wall;

                switch (line[x])
                {
                    case "1":
                        wall = lowWall;
                        break;
                    case "2":
                        wall = highWall;
                        break;
                    default:
                        continue;
                }
                float posX = startPosX + x * terrain.transform.localScale.x / 3f;
                float posZ = startPosZ - y * terrain.transform.localScale.z / 3f;
                GameObject instance = Instantiate(wall, new Vector3(posX, 0f, posZ), Quaternion.identity);
                instance.transform.localScale = new Vector3(terrain.transform.localScale.x / 3f, instance.transform.localScale.y, terrain.transform.localScale.z / 3f);
            }
        }
    }
}
