using UnityEngine;
using System.Collections.Generic;

//List is dynamic -> Add and Remove at runtime and it will resize it
//Array is fixed size
//for loop || foreach
public class RandomMap : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int depth;

    [SerializeField] private List<GameObject> prefabtTilesList = new List<GameObject>();
    [SerializeField] private Transform mapParent;
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject[,] map;
    [SerializeField] private List<List<GameObject>> listMap = new List<List<GameObject>>();
    private float xOffset, zOffset;
    [SerializeField] private float perlinScale;

    private void Start()
    {
        map = new GameObject[width, depth];
        xOffset = Random.Range(1000, 5000);
        zOffset = Random.Range(-1000, 5000);

        BuildRandomMap();
        //Build Perlin Noise Map();
        //Build Wave Function Collapse Map();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            RebuildPerlinMap();
        }
    }

    private void BuildRandomMap()
    {

        for (int row = 0; row < depth; row++)
        {

            List<GameObject> listRow = new List<GameObject>();
            for (int col = 0; col < depth; col++)
            {
                if (row == 0 && col == 0) { continue; }
                Vector3 pos = new Vector3(col * 50, 0f, row * 50);
                GameObject tile = Instantiate(prefabtTilesList[Random.Range(0, prefabtTilesList.Count)], pos, Quaternion.identity, mapParent);
                listRow.Add(tile);
                map[col, row] = tile;
            }
            listMap.Add(listRow);
        }
    }

    private void RebuildPerlinMap()
    {
        listMap.Clear();
        for (int row =0; row< depth; row++)
        {
            for (int col = 0; col < depth; col++)
            {
                Destroy(map[row, col]);
            }
        }
        xOffset = Random.RandomRange(1000, 5000);
        zOffset = Random.RandomRange(-1000, -5000);
        BuildPerlinNoiseMap();

    }
    private void BuildPerlinNoiseMap()
    {
        for (int row = 0; row < depth; row++)
        {

            List<GameObject> listRow = new List<GameObject>();
            for (int col = 0; col < depth; col++)
            {
                if (row == 0 && col == 0) { continue; }
                float perlinNoseValue = GetPerlinNoise(col, row);
                GameObject tile = GenerateTileOnPerlinNoise(perlinNoseValue);
                listRow.Add(tile);
                map[col, row] = tile;
            }
            listMap.Add(listRow);
        }

    }

    private float GetPerlinNoise(float x, float z)
    {
        float xCoord = (x + xOffset) / (width * perlinScale);
        float zCoord = (z + zOffset) / (depth * perlinScale);
        return Mathf.Clamp01(Mathf.PerlinNoise(xCoord, zCoord));
    }

    private GameObject GenerateTileOnPerlinNoise(float noiseValue)
    {

        switch(noiseValue)
        {
            case <= 0.2f: return prefabtTilesList[0]; //Water
            case <= 0.4f: return prefabtTilesList[1];//Grass
            case <= 0.6f: return prefabtTilesList[2]; //Road
            case <= 0.8f: return prefabtTilesList[3]; //Ground
            case <= 1f: return prefabtTilesList[4]; //Lava
            default: return prefabtTilesList[1];




        }
    }
}