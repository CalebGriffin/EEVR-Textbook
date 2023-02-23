using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFlipController : MonoBehaviour
{
    // Get reference to the AutoFlip script
    public AutoFlip autoFlip;

    // Public so it can be called by other scripts or buttons
    public void FlipToPage(int pageNo)
    {
        // Disable the book
        autoFlip.ControledBook.interactable = false;

        // Start the coroutine
        StartCoroutine(FlipToPageCoroutine(pageNo));
    }

    // Private so it can't be called by other scripts or buttons
    IEnumerator FlipToPageCoroutine(int pageNo)
    {
        // If the page number is odd, add 1 to it
        if (pageNo % 2 != 0)
            pageNo++;
        
        // Calculate how many pages to flip
        int pagesToFlip = pageNo - autoFlip.ControledBook.currentPage;

        // For each page to flip, flip it
        for (int i = 0; i < Mathf.Abs(pagesToFlip) / 2; i++)
        {
            // If the number of pages to flip is positive, flip right, otherwise flip left
            // Wait until the page has finished flipping before flipping the next page
            if (pagesToFlip > 0)
            {
                autoFlip.FlipRightPage();
                yield return new WaitUntil(() => autoFlip.isFlipping == false);
            }
            else
            {
                autoFlip.FlipLeftPage();
                yield return new WaitUntil(() => autoFlip.isFlipping == false);
            }
        }

        // Re-enable the book
        autoFlip.ControledBook.interactable = true;
    }
}
