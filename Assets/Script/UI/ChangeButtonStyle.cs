using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonStyle : MonoBehaviour
{
    private Image buttonImage;

    [SerializeField] private List<Sprite> buttonImageList;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void StartFunction() => StartCoroutine(ChangeButton());

    IEnumerator ChangeButton()
    {
        buttonImage.sprite = buttonImageList[1];

        yield return new WaitForSeconds(.1f);

        buttonImage.sprite = buttonImageList[0];
    }
}
