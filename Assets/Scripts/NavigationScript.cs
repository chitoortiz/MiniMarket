using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NavigationScript : MonoBehaviour
{
    [SerializeField] private Transform queue;
    [SerializeField] private Transform exit;

    private ShelfController currShelf;
    private GameObject destinationShelf;

    private State state;

    private List<string> products = new List<string>() { "egg", "milk" };
    private string product;
    
    private TextMeshPro productText;
    
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        productText = GetComponentInChildren<TextMeshPro>();

        state = State.Searching;
        
        product = products[Random.Range(0, products.Count)];
        productText.text = product;
        switch (product)
        {
            case "egg":
                destinationShelf = GameObject.FindWithTag("egg");
                agent.destination = destinationShelf.transform.GetChild(0).transform.position;
                currShelf = destinationShelf.GetComponent<ShelfController>();
                break;
            case "milk":
                destinationShelf = GameObject.FindWithTag("milk");
                agent.destination = destinationShelf.transform.GetChild(0).transform.position;
                currShelf = destinationShelf.GetComponent<ShelfController>();
                break;
        }
    }

    private void Update()
    {
        HandleState();
    }

    private void HandleState()
    {
        switch (state)
        {
            case State.Searching:
                if (transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
                {
                    currShelf.decreaseAmount();
                    toQueueing();
                }
                break;
            case State.Queueing:
                if (transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
                {
                    toLeave();
                }
                break;
            case State.Leaving:
                if (transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
                {
                    Destroy(this);
                }
                break;
            case State.Angry:
                break;
        }
    }

    private void toQueueing()
    {
        agent.destination = queue.position;
        state = State.Queueing;
    }

    private void toLeave()
    {
        agent.destination = exit.position;
        state = State.Leaving;
    }
}

enum State
{
    Searching, Queueing, Leaving, Angry
}