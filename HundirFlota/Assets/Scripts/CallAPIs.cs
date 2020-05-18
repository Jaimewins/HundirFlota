using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CallAPIs : MonoBehaviour
{
    private Vector2 Grande1;
    private Vector2 Grande2;
    private Vector2 Grande3;
    private Vector2 Grande4;
    private Vector2 Grande5;
    private Vector2 Grande6;
    private Vector2 Mediano1;
    private Vector2 Mediano2;
    private Vector2 Mediano3;
    private Vector2 Mediano4;
    private Vector2 Pequeño1;
    private Vector2 Pequeño2;
    private Vector2 Comprovacion;
    private int x;
    private int y;
    private int exploX;
    private int exploY;
    private int contador = 0;
    private int directoX;
    private int directoY;
    [SerializeField] Image tick1;
    [SerializeField] Image tick2;
    [SerializeField] Image tick3;
    [SerializeField] Image tick4;
    [SerializeField] Image tick5;
    [SerializeField] Image tick6;
    [SerializeField] Image tick7;
    [SerializeField] Image tick8;
    [SerializeField] Image cross1;
    [SerializeField] Image cross2;
    [SerializeField] Image cross3;
    [SerializeField] Image cross4;
    [SerializeField] Image cross5;
    [SerializeField] Image cross6;
    [SerializeField] Image cross7;
    [SerializeField] Image cross8;
    [SerializeField] Image cross9;
    [SerializeField] Image cross10;
    [SerializeField] Image cross11;
    [SerializeField] Image cross12;
    [SerializeField] GameObject manager;
    

private string url = "http://localhost:8080/barquitos/";

    // Start is called before the first frame update
    private void Awake()
    {
        IniciaPartida();
        prepararCasillasPlayer();
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
                directoX = placementDX(changeLetterToInt(PlayerPrefs.GetString("ApuntaX")));
                directoY = placementDY(int.Parse(PlayerPrefs.GetString("ApuntaY")));
                manager.GetComponent<Manager>().pegadoNum = manager.GetComponent<Manager>().pegadoNum - 1;
                if (contador == 0)
                {
                    tick1.GetComponent<RectTransform>().anchoredPosition = new Vector2 (directoX, directoY);
                    contador++;
                }
                else if (contador == 1)
                {
                    tick2.GetComponent<RectTransform>().anchoredPosition = new Vector2 (directoX, directoY);
                    contador++;
                }
                else if (contador == 2)
                {
                    tick3.GetComponent<RectTransform>().anchoredPosition = new Vector2 (directoX, directoY);
                    contador++;
                }
                else if (contador == 3)
                {
                    tick4.GetComponent<RectTransform>().anchoredPosition = new Vector2 (directoX, directoY);
                    contador++;
                }
                else if (contador == 4)
                {
                    tick5.GetComponent<RectTransform>().anchoredPosition = new Vector2 (directoX, directoY);
                    contador++;
                }
                else if (contador == 5)
                {
                    tick6.GetComponent<RectTransform>().anchoredPosition = new Vector2 (directoX, directoY);
                    contador++;
                }
                else if (contador == 6)
                {
                    tick7.GetComponent<RectTransform>().anchoredPosition = new Vector2 (directoX, directoY);
                    contador++;
                }
                else if (contador == 7)
                {
                    tick8.GetComponent<RectTransform>().anchoredPosition = new Vector2 (directoX, directoY);
                    contador++;
                }
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
            Comprovacion = new Vector2(int.Parse(aw.dispX), int.Parse(aw.dispY));
            if (Comprovacion == Grande1)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross1.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Grande1 = new Vector2(10, 10);
            }
            else if (Comprovacion == Grande2)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross2.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Grande2 = new Vector2(10, 10);
            }
            else if (Comprovacion == Grande3)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross3.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Grande3 = new Vector2(10, 10);
            }
            else if (Comprovacion == Grande4)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross4.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Grande4 = new Vector2(10, 10);
            }
            else if (Comprovacion == Grande5)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross5.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Grande5 = new Vector2(10, 10);
            }
            else if (Comprovacion == Grande6)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross6.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Grande6 = new Vector2(10, 10);
            }
            else if (Comprovacion == Mediano1)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross7.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Mediano1 = new Vector2(10, 10);
            }
            else if (Comprovacion == Mediano2)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross8.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Mediano2 = new Vector2(10, 10);
            }
            else if (Comprovacion == Mediano3)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross9.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Mediano3 = new Vector2(10, 10);
            }
            else if (Comprovacion == Mediano4)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross10.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Mediano4 = new Vector2(10, 10);
            }
            else if (Comprovacion == Pequeño1)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross11.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Pequeño1 = new Vector2(10, 10);
            }
            else if (Comprovacion == Pequeño2)
            {
                exploX = placementX(aw.dispX);
                exploY = placementY(aw.dispY);
                cross12.GetComponent<RectTransform>().anchoredPosition = new Vector2 (exploX, exploY);
                manager.GetComponent<Manager>().recibidoNum = manager.GetComponent<Manager>().recibidoNum - 1;
                Pequeño2 = new Vector2(10, 10);
            } 
        } else {
            Debug.Log("asgf    " + jsondata);
        }
    }

    private void prepararCasillasPlayer()
    {
        x = changeLetterToInt(PlayerPrefs.GetString("XG"));
        y = int.Parse(PlayerPrefs.GetString("YG"))-1;
        Grande1 = new Vector2 (x, y);
        Grande2 = new Vector2 (x, y + 1);
        Grande3 = new Vector2 (x, y + 2);
        Grande4 = new Vector2 (x, y + 3);
        Grande5 = new Vector2 (x, y + 4);
        Grande6 = new Vector2 (x, y + 5);
        x = changeLetterToInt(PlayerPrefs.GetString("XM"));
        y = int.Parse(PlayerPrefs.GetString("YM"))-1;
        Mediano1 = new Vector2 (x, y);
        Mediano2 = new Vector2 (x, y + 1);
        Mediano3 = new Vector2 (x, y + 2);
        Mediano4 = new Vector2 (x, y + 3);
        x = changeLetterToInt(PlayerPrefs.GetString("XP"));
        y = int.Parse(PlayerPrefs.GetString("YP"))-1;
        Mediano1 = new Vector2 (x, y);
        Mediano2 = new Vector2 (x, y + 1);
    }

    private int changeLetterToInt(string letra){
        int numero;

        switch (letra)
        {
            case "A":
                numero = 0;
                break;
            case "B":
                numero = 1;
                break;
            case "C":
                numero = 2;
                break;
            case "D":
                numero = 3;
                break;
            case "E":
                numero = 4;
                break;
            case "F":
                numero = 5;
                break;
            case "G":
                numero = 6;
                break;
            case "H":
                numero = 7;
                break;
            case "I":
                numero = 8;
                break;
            case "J":
                numero = 9;
                break;
            default:
                numero = 0;
                break;
        }

        return numero;
    }

    private int placementX(string coor)
    {
        int numero2 = 0;
        switch (coor)
        {
            case "0":
                numero2 = -40;
                break;
            case "1":
                numero2 = 50;
                break;
            case "2":
                numero2 = 150;
                break;
            case "3":
                numero2 = 240;
                break;
            case "4":
                numero2 = 340;
                break;
            case "5":
                numero2 = 430;
                break;
            case "6":
                numero2 = 530;
                break;
            case "7":
                numero2 = 620;
                break;
            case "8":
                numero2 = 720;
                break;
            case "9":
                numero2 = 810;
                break;
            default:
                break;
        }
        return numero2;
    }

    private int placementY(string coor)
    {
        int numero3 = 0;
        switch (coor)
        {
            case "0":
                numero3 = 390;
                break;
            case "1":
                numero3 = 300;
                break;
            case "2":
                numero3 = 200;
                break;
            case "3":
                numero3 = 110;
                break;
            case "4":
                numero3 = 10;
                break;
            case "5":
                numero3 = -80;
                break;
            case "6":
                numero3 = -180;
                break;
            case "7":
                numero3 = -270;
                break;
            case "8":
                numero3 = -370;
                break;
            case "9":
                numero3 = -460;
                break;
            default:
                break;
        }
        return numero3;
    }

    private int placementDX(int coor)
    {
        int numero2 = 0;
        switch (coor)
        {
            case 0:
                numero2 = -40;
                break;
            case 1:
                numero2 = 50;
                break;
            case 2:
                numero2 = 150;
                break;
            case 3:
                numero2 = 240;
                break;
            case 4:
                numero2 = 340;
                break;
            case 5:
                numero2 = 430;
                break;
            case 6:
                numero2 = 530;
                break;
            case 7:
                numero2 = 620;
                break;
            case 8:
                numero2 = 720;
                break;
            case 9:
                numero2 = 810;
                break;
            default:
                break;
        }
        return numero2;
    }

    private int placementDY(int coor)
    {
        int numero3 = 0;
        switch (coor)
        {
            case 1:
                numero3 = 390;
                break;
            case 2:
                numero3 = 300;
                break;
            case 3:
                numero3 = 200;
                break;
            case 4:
                numero3 = 110;
                break;
            case 5:
                numero3 = 10;
                break;
            case 6:
                numero3 = -80;
                break;
            case 7:
                numero3 = -180;
                break;
            case 8:
                numero3 = -270;
                break;
            case 9:
                numero3 = -370;
                break;
            case 10:
                numero3 = -460;
                break;
            default:
                break;
        }
        return numero3;
    }
}