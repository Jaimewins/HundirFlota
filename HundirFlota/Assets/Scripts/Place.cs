using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    [SerializeField] private Image gran;
    [SerializeField] private Image med;
    [SerializeField] private Image peq;
    [SerializeField] private CallAPIs callAPIs;
    private int PosGX;
    private int PosGY;
    private int PosMX;
    private int PosMY;
    private int PosPX;
    private int PosPY;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetString("XG"))
        {
            case "A":
                PosGX = -40;
                break;
            case "B":
                PosGX = 50;
                break;
            case "C":
                PosGX = 150;
                break;
            case "D":
                PosGX = 240;
                break;
            case "E":
                PosGX = 340;
                break;
            case "F":
                PosGX = 430;
                break;
            case "G":
                PosGX = 530;
                break;
            case "H":
                PosGX = 620;
                break;
            case "I":
                PosGX = 720;
                break;
            case "J":
                PosGX = 810;
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetString("YG"))
        {
            case "1":
                PosGY = 390;
                break;
            case "2":
                PosGY = 300;
                break;
            case "3":
                PosGY = 200;
                break;
            case "4":
                PosGY = 110;
                break;
            case "5":
                PosGY = 10;
                break;
            case "6":
                PosGY = -80;
                break;
            case "7":
                PosGY = -180;
                break;
            case "8":
                PosGY = -270;
                break;
            case "9":
                PosGY = -370;
                break;
            case "10":
                PosGY = -460;
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetString("XM"))
        {
            case "A":
                PosMX = -40;
                break;
            case "B":
                PosMX = 50;
                break;
            case "C":
                PosMX = 150;
                break;
            case "D":
                PosMX = 240;
                break;
            case "E":
                PosMX = 340;
                break;
            case "F":
                PosMX = 430;
                break;
            case "G":
                PosMX = 530;
                break;
            case "H":
                PosMX = 620;
                break;
            case "I":
                PosMX = 720;
                break;
            case "J":
                PosMX = 810;
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetString("YM"))
        {
            case "1":
                PosMY = 390;
                break;
            case "2":
                PosMY = 300;
                break;
            case "3":
                PosMY = 200;
                break;
            case "4":
                PosMY = 110;
                break;
            case "5":
                PosMY = 10;
                break;
            case "6":
                PosMY = -80;
                break;
            case "7":
                PosMY = -180;
                break;
            case "8":
                PosMY = -270;
                break;
            case "9":
                PosMY = -370;
                break;
            case "10":
                PosMY = -460;
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetString("XP"))
        {
            case "A":
                PosPX = -40;
                break;
            case "B":
                PosPX = 50;
                break;
            case "C":
                PosPX = 150;
                break;
            case "D":
                PosPX = 240;
                break;
            case "E":
                PosPX = 340;
                break;
            case "F":
                PosPX = 430;
                break;
            case "G":
                PosPX = 530;
                break;
            case "H":
                PosPX = 620;
                break;
            case "I":
                PosPX = 720;
                break;
            case "J":
                PosPX = 810;
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetString("YP"))
        {
            case "1":
                PosPY = 390;
                break;
            case "2":
                PosPY = 300;
                break;
            case "3":
                PosPY = 200;
                break;
            case "4":
                PosPY = 110;
                break;
            case "5":
                PosPY = 10;
                break;
            case "6":
                PosPY = -80;
                break;
            case "7":
                PosPY = -180;
                break;
            case "8":
                PosPY = -270;
                break;
            case "9":
                PosPY = -370;
                break;
            case "10":
                PosPY = -460;
                break;
            default:
                break;
        }
        gran.GetComponent<RectTransform>().anchoredPosition = new Vector2 (PosGX, PosGY);
        med.GetComponent<RectTransform>().anchoredPosition = new Vector2 (PosMX, PosMY);
        peq.GetComponent<RectTransform>().anchoredPosition = new Vector2 (PosPX, PosPY);
        switch (PlayerPrefs.GetInt("SentidoG"))
        {
            case 0:
                break;
            case 90:
                gran.GetComponent<RectTransform>().Rotate(0, 0, 90);
                break;
            case 180:
                gran.GetComponent<RectTransform>().Rotate(0, 0, 90);
                gran.GetComponent<RectTransform>().Rotate(0, 0, 90);
                break;
            case 270:
                gran.GetComponent<RectTransform>().Rotate(0, 0, -90);
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetInt("SentidoM"))
        {
            case 0:
                break;
            case 90:
                med.GetComponent<RectTransform>().Rotate(0, 0, 90);
                break;
            case 180:
                med.GetComponent<RectTransform>().Rotate(0, 0, 90);
                med.GetComponent<RectTransform>().Rotate(0, 0, 90);
                break;
            case 270:
                med.GetComponent<RectTransform>().Rotate(0, 0, -90);
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetInt("SentidoP"))
        {
            case 0:
                break;
            case 90:
                peq.GetComponent<RectTransform>().Rotate(0, 0, 90);
                break;
            case 180:
                peq.GetComponent<RectTransform>().Rotate(0, 0, 90);
                peq.GetComponent<RectTransform>().Rotate(0, 0, 90);
                break;
            case 270:
                peq.GetComponent<RectTransform>().Rotate(0, 0, -90);
                break;
            default:
                break;
        }

        callAPIs.InicializarBarcoIA();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
