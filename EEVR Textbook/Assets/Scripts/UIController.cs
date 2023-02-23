using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject switchButton;
    [SerializeField] private GameObject menuParent;
    [SerializeField] private GameObject bookParent;
    [SerializeField] private GameObject calculatorParent;
    [SerializeField] private GameObject switchButtonArrow;

    private bool lookingAtBook = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        LeanTween.moveLocalY(menuParent, 1080, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.moveLocalY(bookParent, 0, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.value(switchButton, -1180, -100, 0.5f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnUpdate((float val) =>
            {
                switchButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-85, val);
            });
    }

    public void SwitchButton()
    {
        if (lookingAtBook)
        {
            switchButton.GetComponent<Button>().interactable = false;
            LeanTween.moveLocalY(bookParent, 1080, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            LeanTween.moveLocalY(calculatorParent, 0, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            LeanTween.rotateZ(switchButtonArrow, 180, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            lookingAtBook = false;
            switchButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            switchButton.GetComponent<Button>().interactable = false;
            LeanTween.moveLocalY(calculatorParent, -1080, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            LeanTween.moveLocalY(bookParent, 0, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            LeanTween.rotateZ(switchButtonArrow, 0, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            switchButton.GetComponent<Button>().interactable = true;
            lookingAtBook = true;
        }

    }
}
