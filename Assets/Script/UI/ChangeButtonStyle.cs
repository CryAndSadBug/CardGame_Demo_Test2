using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonStyle : MonoBehaviour
{
    private Image buttonImage;

    private TextMeshProUGUI buttonText;

    [SerializeField] private Color defualfontColor;
    [SerializeField] private Color fontColor;
    [SerializeField] private List<Sprite> buttonImageList;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void StartFunction() => StartCoroutine(ChangeButton());

    IEnumerator ChangeButton()
    {
        buttonImage.sprite = buttonImageList[1];
        buttonText.fontSize = 21;
        buttonText.color = fontColor;

        yield return new WaitForSeconds(.1f);

        buttonImage.sprite = buttonImageList[0];
        buttonText.fontSize = 24;
        buttonText.color = defualfontColor;
    }
}
