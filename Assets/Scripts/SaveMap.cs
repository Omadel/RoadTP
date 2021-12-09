using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class SaveMap : MonoBehaviour
{
    List<Vector2Int> positions = new List<Vector2Int>();
    string filePath = "Assets/Ressources/MapSaving.txt";

    private void Start()
    {
        filePath = "Assets/Ressources/MapSaving.txt";

        positions.Add(new Vector2Int(1,2));
        positions.Add(new Vector2Int(1,1));
        positions.Add(new Vector2Int(2,2));
        positions.Add(new Vector2Int(2,1));
        positions.Add(new Vector2Int(0,1));
        positions.Add(new Vector2Int(1,0));
        

        SaveIntoTxt();

        LoadTxt();
    }

    [ContextMenu("Save")]
    void SaveIntoTxt()
    {
        StreamWriter writer = new StreamWriter(filePath, false);

        foreach (var item in positions)
        {
            writer.WriteLine(item.x + "," + item.y);
        }

        writer.Close();

        Debug.Log("coucou");

        AssetDatabase.ImportAsset(filePath);

        LoadTxt();
    }


    [ContextMenu("Load")]
    void LoadTxt()
    {
        StreamReader reader = new StreamReader(filePath);
        string line = reader.ReadLine();
        positions = new List<Vector2Int>();
        while (line != null && line.Length > 2)
        {
            positions.Add(new Vector2Int((int)char.GetNumericValue(line[0]), (int)char.GetNumericValue(line[2])));
            line = reader.ReadLine();
        }
    }


}
