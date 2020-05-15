using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPlacement : MonoBehaviour
{
    [SerializeField] private Image gran;
    [SerializeField] private Image med;
    [SerializeField] private Image peq;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnLeft()
    {
        gran.GetComponent<RectTransform>().Rotate(0, 0, -90);
    }

    public void TurnRight()
    {
        gran.GetComponent<RectTransform>().Rotate(0, 0, 90);
    }
}
