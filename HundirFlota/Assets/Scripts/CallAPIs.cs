﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CallAPIs : MonoBehaviour
{

private string url = "http://localhost:8080/barquitos/";
    [SerializeField] private Button button;

    // Start is called before the first frame update
    private void Start()
    {
        IniciaPartida();
    }

    void IniciaPartida()
    {
        /*frameActual.sprite = ahorcadoFrames[0];
        palabraCifrada.text = "";
        texto.text = "";
        nframeActual = 0;*/

        //Cargar primera llamada
        StartCoroutine(CargaMatriz());
    }

    IEnumerator CargaMatriz()
    {

        // Hacer la llamada http/https a la api url + currenword
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url+"cargamatriz"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Received: " + webRequest.downloadHandler.text);
            }
        }       
    }

    public void InicializarBarcos()
    {
        button.interactable = false;

        Barcos bP = new Barcos();

        bP.tipo = "P";
        bP.posicionInicial[0] = 5;
        bP.posicionInicial[1] = 0;
        bP.direccion = 0;
        bP.tamano = 2;

        Barcos bM = new Barcos();

        bM.tipo = "M";
        bM.posicionInicial[0] = 7;
        bM.posicionInicial[1] = 0;
        bM.direccion = 0;
        bM.tamano = 4;

        Barcos bG = new Barcos();

        bG.tipo = "G";
        bG.posicionInicial[0] = 3;
        bG.posicionInicial[1] = 0;
        bG.direccion = 0;
        bG.tamano = 6;

        StartCoroutine(ColocarBarcos(bP));
        StartCoroutine(ColocarBarcos(bM));
        StartCoroutine(ColocarBarcos(bG));
    }

    IEnumerator ColocarBarcos(Barcos barcos){
    
        string json = JsonUtility.ToJson(barcos);

        WWWForm form = new WWWForm();
        form.AddField("json", json);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url + "colocarbarcos", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
                Debug.Log("Ha pasado algo");
                Debug.Log(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}