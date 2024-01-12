using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    private GameObject customer;
    
    // Start is called before the first frame update
    void Start()
    {
        customer = Resources.Load<GameObject>("Customer");
        Instantiate(customer, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
