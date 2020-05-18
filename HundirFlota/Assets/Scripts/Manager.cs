using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] Text recibido;
    [SerializeField] Text pegado;
    [SerializeField] Text turnos;
    public int recibidoNum = 8;
    public int pegadoNum = 8;
    public int turnosNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recibido.GetComponent<Text>().text = recibidoNum.ToString();
        pegado.GetComponent<Text>().text = pegadoNum.ToString();
        turnos.GetComponent<Text>().text = turnosNum.ToString();
        if (recibidoNum <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
        if (pegadoNum <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
