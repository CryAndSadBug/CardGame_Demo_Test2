using TMPro;
using UnityEngine;

public class CardIntroduce_UI : MonoBehaviour
{
    public static CardIntroduce_UI instance;

    private TextMeshProUGUI cardName;
    private TextMeshProUGUI cardType;
    private TextMeshProUGUI cardIntroduce;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }

    private void Start()
    {
        cardName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        cardIntroduce = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        cardType = transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        if (MyCard.instance.myCards.Count <= 0)
            Hide();
    }

    public void SetIntroduce(Cards _target, string _cardName, string _cardType, string _cardIntroduce)
    {
        cardName.text = _cardName;
        cardType.text = _cardType;
        cardIntroduce.text = _cardIntroduce;

        if (cardName.text.Length >= 16)
        {
            cardName.fontSize = 11;
        } else
        {
            cardName.fontSize = 20;
        }
    }

    public void Show() => transform.gameObject.SetActive(true);
    public void Hide() => transform.gameObject.SetActive(false);
}
