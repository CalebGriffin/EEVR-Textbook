using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] AutoFlip autoFlip;

    [SerializeField] Button[] contentsPageButtons;

    [SerializeField] Button contentsPageButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (autoFlip.isFlipping)
        {
            SetContentsPageButtons(false);
            contentsPageButton.interactable = false;
        }
        else
        {
            SetContentsPageButtons(true);
            contentsPageButton.interactable = true;
        }

        if (autoFlip.ControledBook.currentPage != 0)
        {
            contentsPageButton.gameObject.SetActive(true);
            SetContentsPageButtons(false);
        }
        else
        {
            contentsPageButton.gameObject.SetActive(false);
            SetContentsPageButtons(true);
        }
    }

    void SetContentsPageButtons(bool to)
    {
        foreach (Button button in contentsPageButtons)
        {
            button.interactable = to;
        }
    }
}
