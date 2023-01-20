using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    // Start is called before the first frame update

    public Button toggleButton;
    public Image toggleImage;
    public bool isVisible = false;


    void Start()
    {
        if (isVisible == false)
        {
            toggleImage.enabled = false;
        }
        toggleButton.onClick.AddListener(ToggleImage);
    }

    void ToggleImage()
    {
        if (isVisible)
        {
            toggleImage.enabled = false;
        }
        else
        {
            toggleImage.enabled = true;
        }

        isVisible = !isVisible;
    }
}
