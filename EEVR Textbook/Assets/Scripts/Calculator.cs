using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NCalc;

public class Calculator : MonoBehaviour
{
    private string displayString = "";
    private string calculationString = "";

    private string lastDisplayString = "";
    private string lastCalculationString = "";

    private bool justCalculated = false;

    [SerializeField] private TextMeshProUGUI displayText;

    private Dictionary<string, string> unicodeConversions = new Dictionary<string, string>()
    {
        {"/", "\u00F7"},
        {"*", "\u00D7"},
        {"-", "\u2212"},
        {"+", "\u002B"}
    };

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateDisplay()
    {
        displayText.text = displayString;
    }

    public void ButtonPressed(string value)
    {
        if (displayString == "Error")
        {
            displayString = "";
            calculationString = "";
        }

        if (unicodeConversions.ContainsKey(value))
        {
            if (calculationString == "")
                return;
            if (unicodeConversions.ContainsKey(calculationString[calculationString.Length - 1].ToString()))
                return;
            displayString += unicodeConversions[value];
            lastDisplayString = unicodeConversions[value];
        }
        else
        {
            displayString += value;
            lastDisplayString = value;
        }

        calculationString += value;
        lastCalculationString = value;

        UpdateDisplay();
    }

    private bool HasErrors()
    {
        return new Expression(calculationString).HasErrors();
    }

    public void Calculate()
    {
        if (calculationString == "")
            return;
        
        if (HasErrors())
        {
            displayString = "Error";
            calculationString = "";
            lastDisplayString = "";
            lastCalculationString = "";
            UpdateDisplay();
            return;
        }

        displayString = new Expression(calculationString).Evaluate().ToString();
        calculationString = displayString;
        lastDisplayString = "";
        lastCalculationString = "";
        UpdateDisplay();
        justCalculated = true;
    }

    public void Clear()
    {
        displayString = "";
        calculationString = "";
        lastDisplayString = "";
        lastCalculationString = "";
        UpdateDisplay();
    }

    public void Backspace()
    {
        if (justCalculated)
        {
            justCalculated = false;
            Clear();
            return;
        }
        if (displayString == "")
            return;
        
        if (displayString == "Error")
        {
            displayString = "";
            calculationString = "";
            UpdateDisplay();
            return;
        }

        displayString = displayString.Substring(0, displayString.Length - (1 * lastDisplayString.Length));
        calculationString = calculationString.Substring(0, calculationString.Length - (1 * lastCalculationString.Length));

        UpdateDisplay();
    }
}
