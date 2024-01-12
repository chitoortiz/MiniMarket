using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShelfController : MonoBehaviour
{
    [SerializeField] private TextMeshPro textAmount;
    
    [SerializeField] private string product;
    [SerializeField] private int maxAmount;
    private int amount;
    
    
    // Start is called before the first frame update
    void Start()
    {
        amount = maxAmount;
    }

    private void Update()
    {
        textAmount.text = amount.ToString();
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
