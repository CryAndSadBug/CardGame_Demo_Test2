using UnityEngine;
using UnityEngine.UI;

public class Buttons_UI : MonoBehaviour
{
    private MyCard myCard;

    [SerializeField] private Button deleteButton;
    [SerializeField] private Button sendButton;

    private void Start()
    {
        myCard = MyCard.instance;

        if (deleteButton != null)
            deleteButton.onClick.AddListener(myCard.DeleteCard);
        if(sendButton != null)
            sendButton.onClick.AddListener(myCard.SendCard);
    }
}
