using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController : MonoBehaviour
{
    [SerializeField] private string product;
    [SerializeField] private int maxAmount;
    private int amount;
    
    // Start is called before the first frame update
    void Start()
    {
        amount = maxAmount;
    }

    public void decreaseAmount()
    {
        amount--;
    }

    public void increaseAmount()
    {
        amount++;
    }
}
