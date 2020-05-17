using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coordenadas
{
    public int[] coordenadas = new int[2];

    public string tipoBarco;

    public string destruido;

    public static Coordenadas CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Coordenadas>(jsonString);
    }

    public static string CreateJSON(Coordenadas b)
    {
        return JsonUtility.ToJson(b);
    }
}