using System.Collections.Generic;
using UnityEngine;

public class CheckCard_Box : MonoBehaviour
{
    static public CheckCard_Box instance;

    public List<Transform> sendCards;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }
}
