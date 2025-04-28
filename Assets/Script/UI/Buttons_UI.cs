using UnityEngine;
using UnityEngine.UI;

public class Buttons_UI : MonoBehaviour
{
    private MyCard myCard;

    [SerializeField] private Button deleteButton;

    private void Start()
    {
        myCard = MyCard.instance;

        if (deleteButton != null)
        {
            deleteButton.onClick.AddListener(myCard.DeleteCard);
        }
    }
}
