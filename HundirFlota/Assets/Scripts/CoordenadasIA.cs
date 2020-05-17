using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoordenadasIA
{
    public string dispX;

    public string dispY;

    public static CoordenadasIA CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<CoordenadasIA>(jsonString);
    }

    public static string CreateJSON(CoordenadasIA b)
    {
        return JsonUtility.ToJson(b);
    }
}