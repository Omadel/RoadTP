using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backup : MonoBehaviour
{
    List<Position> positions = new List<Position>();

    void SaveIntoJson()
    {
        foreach (Position pos in positions)
        {
            string poss = JsonUtility.ToJson(pos);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/MapSave.json", poss);
        }
    }



}
