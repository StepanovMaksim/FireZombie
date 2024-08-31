using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamGuns : MonoBehaviour
{
    [SerializeField] GameObject[] _paramsText; 
    [SerializeField] Text[] _paramsTextLabel; 
    
    public static float Speed = 30;
    public static float Strength = 20;
    public static float Distance = 50;

    void Start()
    {
        
    }
    public void GetDamage(float damage)
    {
        var value = Random.Range(0, 3);
        if (value == 0)
            Speed -= damage;
        else if (value == 1)
            Strength -= damage;
        else if (value == 2)
            Distance -= damage;
        for (int i = 0; i < _paramsText.Length; i++)
        {
            if (value == i)
            {
                _paramsTextLabel[i].text = "-" + damage;
                _paramsText[i].SetActive(true);
            }
                
            else
                _paramsText[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
