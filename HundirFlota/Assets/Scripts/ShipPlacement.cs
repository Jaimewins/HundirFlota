using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPlacement : MonoBehaviour
{
    [SerializeField] private Image gran;
    [SerializeField] private Image med;
    [SerializeField] private Image peq;
    [SerializeField] private Text Letter;
    [SerializeField] private Text Number;
    private int SentidoGrande;
    private int SentidoMediano;
    private int SentidoPequeño;
    private string PosXG;
    private string PosXM;
    private string PosXP;
    private string PosYG;
    private string PosYM;
    private string PosYP;
    private Image currentShip;
    private int currentDegree;
    private string currentX;
    private string currentY;
    private bool place = false;
    private bool place2 = false;

    // Start is called before the first frame update
    void Start()
    {
        currentShip = gran;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void SendShip()
    {
        currentX = Letter.GetComponent<Text>().text;
        currentY = Number.GetComponent<Text>().text;
        if (currentX == "A")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-40, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "B")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (50, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "C")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (150, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "D")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (240, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "E")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (340, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "F")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (430, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "G")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (530, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "H")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (620, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "I")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (720, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (currentX == "J")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (810, currentShip.GetComponent<RectTransform>().anchoredPosition.y);
        }
        if (currentY == "1")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, 390);
        }
        else if (currentY == "2")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, 300);
        }
        else if (currentY == "3")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, 200);
        }
        else if (currentY == "4")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, 110);
        }
        else if (currentY == "5")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, 10);
        }
        else if (currentY == "6")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, -80);
        }
        else if (currentY == "7")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, -180);
        }
        else if (currentY == "8")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, -270);
        }
        else if (currentY == "9")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, -370);
        }
        else if (currentY == "10")
        {
            currentShip.GetComponent<RectTransform>().anchoredPosition = new Vector2 (currentShip.GetComponent<RectTransform>().anchoredPosition.x, -460);
        }
        if (place == true && place2 == true)
        {
            SentidoPequeño = currentDegree;
            currentDegree = 0;
            PosXP = currentX;
            PosYP = currentY;
        }
        if (place == true && place2 == false)
        {
            SentidoMediano = currentDegree;
            currentDegree = 0;
            PosXM = currentX;
            PosYM = currentY;
            place2 = true;
            currentShip = peq;
        }
        if (place == false)
        {
            SentidoGrande = currentDegree;
            currentDegree = 0;
            PosXG = currentX;
            PosYG = currentY;
            place = true;
            currentShip = med;
        }
    }

    public void TurnLeft()
    {
        currentShip.GetComponent<RectTransform>().Rotate(0, 0, -90);
        currentDegree = currentDegree - 90;
        if (currentDegree == -90)
        {
            currentDegree = 270;
        }
    }

    public void TurnRight()
    {
        currentShip.GetComponent<RectTransform>().Rotate(0, 0, 90);
        currentDegree = currentDegree + 90;
        if (currentDegree == 360)
        {
            currentDegree = 0;
        }
    }
}
