using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CallAPIs : MonoBehaviour
{

private string url = "http://localhost:8080/barquitos/";

    // Start is called before the first frame update
    private void Awake()
    {
        IniciaPartida();
    }

    void IniciaPartida()
    {
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


    public void Disparar(Coordenadas coordenadas)
    {
        StartCoroutine(DispararPlayer(coordenadas));
        StartCoroutine(DispararIA());
    }

    public void InicializarBarcoP(Barcos bP)
    {
        StartCoroutine(ColocarBarcos1(bP));
    }

    public void InicializarBarcoM(Barcos bM)
    {
        StartCoroutine(ColocarBarcos2(bM));
    }

    public void InicializarBarcoG(Barcos bG)
    {
        StartCoroutine(ColocarBarcos3(bG));
    }

    public void InicializarBarcoIA()
    {
        StartCoroutine(ColocarBarcosIA());
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

    IEnumerator ColocarBarcos1(Barcos barcos){
    
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

    IEnumerator ColocarBarcos2(Barcos barcos){
    
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

    IEnumerator ColocarBarcos3(Barcos barcos){
    
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
    IEnumerator ColocarBarcosIA(){
    
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url + "colocarbarcosia"))
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

    IEnumerator DispararPlayer(Coordenadas coordenadas){
    
    string json = JsonUtility.ToJson(coordenadas);
        string jsondata = "";

    WWWForm form = new WWWForm();
    form.AddField("json", json);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url + "dispararplayer", form))
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
                jsondata = webRequest.downloadHandler.text;
            }
        }

        // Procesar el JSON y obtener la palabra cifrada
        if (jsondata != "")
        {
            Debug.Log(jsondata);
            Coordenadas aw = Coordenadas.CreateFromJSON(jsondata);
         

            if (aw.tipoBarco != "A")
            {
                // aw contiene los datos de .tipoBarco que son PIA  MIA  GIA o A (este ultimo quiere decir que no has dado a ninguno (AGUA))

                // si tipoBarco devuelve "A" quiere decir que no has acertado a ningun barco
                Debug.Log("HE DADOD HA:  "+ aw.tipoBarco);
                // .destruido te dira "SI" si has destruido por completo ese tipo de barco o "NO" si no lo has destruido por completo
                Debug.Log("SI LO HE DESTRUIDO:  "+ aw.destruido);
            }
            else
            {
                Debug.Log("AGUA");
            }
        } else {
            Debug.Log("asgf    " + jsondata);
        }
    }

    IEnumerator DispararIA(){
        
        
        string jsondata = "";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url + "dispararia"))
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
                jsondata = webRequest.downloadHandler.text;
            }
        }

        // Procesar el JSON y obtener la palabra cifrada
        if (jsondata != "")
        {
            Debug.Log(jsondata);
            CoordenadasIA aw = CoordenadasIA.CreateFromJSON(jsondata);

            // aw te devuelve la posicion en X y en Y de donde ha disparado la IA
            Debug.Log("DISPARO EN X:  "+ aw.dispX);
            Debug.Log("DISPARO EN Y:  "+ aw.dispY);
            
        } else {
            Debug.Log("asgf    " + jsondata);
        }
    }
}