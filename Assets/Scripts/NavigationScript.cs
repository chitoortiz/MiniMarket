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
    //VAGINA
    [SerializeField] private Transform eggIsle;
    [SerializeField] private Transform milkIsle;
    [SerializeField] private Transform queue;
    [SerializeField] private Transform exit;

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
        agent.destination = product switch
        {
            "egg" => eggIsle.position,
            "milk" => milkIsle.position,
            _ => agent.destination
        };
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