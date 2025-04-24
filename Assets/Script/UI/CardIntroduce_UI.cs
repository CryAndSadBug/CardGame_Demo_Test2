using UnityEngine;

public class CardIntroduce_UI : MonoBehaviour
{
    public static CardIntroduce_UI instance;

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

    public void Show() => transform.gameObject.SetActive(true);
    public void Hide() => transform.gameObject.SetActive(false);
}
