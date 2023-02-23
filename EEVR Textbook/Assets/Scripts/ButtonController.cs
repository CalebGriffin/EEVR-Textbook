using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] AutoFlip autoFlip;

    [SerializeField] Button[] contentsPageButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (autoFlip.ControledBook.currentPage != 0)
        {
            foreach (Button button in contentsPageButtons)
            {
                button.interactable = false;
            }
        }
        else
        {
            foreach (Button button in contentsPageButtons)
            {
                button.interactable = true;
            }
        }
    }
}
