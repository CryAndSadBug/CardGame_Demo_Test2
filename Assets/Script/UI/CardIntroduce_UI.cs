using UnityEngine;

public class CardIntroduce_UI : MonoBehaviour
{
    public static CardIntroduce_UI Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }else
        {
            Instance = this;
        }
    }

    public void Show() => transform.gameObject.SetActive(true);

    public void Hide() => transform.gameObject.SetActive(false);
}
