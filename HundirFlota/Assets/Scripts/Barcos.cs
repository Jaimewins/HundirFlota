using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Barcos
{
    public int[] posicionInicial = new int[2];
    public int direccion;
    public int tamano;
    public string tipo;

    public static Barcos CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Barcos>(jsonString);
    }

    public static string CreateJSON(Barcos b)
    {
        return JsonUtility.ToJson(b);
    }
}
