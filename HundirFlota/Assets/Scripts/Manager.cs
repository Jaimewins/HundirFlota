using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] Text recibido;
    [SerializeField] Text turnos;
    public int recibidoNum = 12;
    public int turnosNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recibido.GetComponent<Text>().text = recibidoNum.ToString();
        turnos.GetComponent<Text>().text = turnosNum.ToString();
    }
}
