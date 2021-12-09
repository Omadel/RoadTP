using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class SaveMap : MonoBehaviour
{
    private List<Vector3Int> _positions;
    private string _filePath = "Assets/Ressources/MapSaving.txt";
    public PaintBrush _paintBrush;

    [ContextMenu("Save")]
    public void SaveIntoTxt()
    {
        _positions = _paintBrush.GetMap();

        StreamWriter writer = new StreamWriter(_filePath, false);

        foreach (var item in _positions)
        {
            writer.WriteLine(item.x + "," + item.y + "," + item.z);
        }

        writer.Close();

        Debug.Log("saved");

        AssetDatabase.ImportAsset(_filePath);
    }


    [ContextMenu("Load")]
    public void LoadTxt()
    {
        _paintBrush.CleanMap();

        StreamReader reader = new StreamReader(_filePath);
        string line = reader.ReadLine();
        _positions = new List<Vector3Int>();
        while (line != null && line.Length > 2)
        {
            string[] split = line.Split(',');
            _positions.Add(new Vector3Int(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
            line = reader.ReadLine();
        }

        foreach (var item in _positions)
        {
            _paintBrush.Paint(item);
        }
    }
}
