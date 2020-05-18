using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 120;
    }

    // Update is called once per frame
    void Update()
    {
        counter--;
        if (counter <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
