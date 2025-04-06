using System.Collections.Generic;
using UnityEngine;

public class MyCard : MonoBehaviour
{

    [SerializeField] private List<Transform> myCards;

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            myCards.Add(child);
        }
    }
}
