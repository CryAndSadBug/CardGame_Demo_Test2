using UnityEngine;
using UnityEngine.UI;

public class Buttons_UI : MonoBehaviour
{
    private MyCard_Box myCard;

    [SerializeField] private Button deleteButton;
    [SerializeField] private Button sendButton;

    private void Start()
    {
        myCard = MyCard_Box.instance;

        if (deleteButton != null)
            deleteButton.onClick.AddListener(myCard.DeleteCard);
        if(sendButton != null)
            sendButton.onClick.AddListener(myCard.SendCard);
    }
}
