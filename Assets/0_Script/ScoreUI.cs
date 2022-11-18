using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{






    public TextMeshProUGUI _text; 


    public void SetText(string text)
    {
        _text.text = text;
    }
}
