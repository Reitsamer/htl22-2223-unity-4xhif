using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberComponentScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int lowerBound = 0;
    public int upperBound = 59;
    
    public void Increase()
    {
        int number = int.Parse(text.text);
        number = (number + 1) % upperBound;
        
        text.text = number.ToString("D2");
    }

    public void Decrease()
    {
        int number = int.Parse(text.text);
        number = ((number - 1) < lowerBound) ? upperBound - 1 : number - 1;
        
        text.text = number.ToString("D2");
    }

    public void ChangeValue(int value)
    {
        int number = int.Parse(text.text);
        number += value;

        if (number >= upperBound)
            number = lowerBound;
        else if (number <= lowerBound)
            number = upperBound - 1;
        
        text.text = number.ToString("D2");
    }
}
