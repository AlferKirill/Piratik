using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float StoppingDistance;
    public float RetriatDistance;


    public Transform Player;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) > StoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Player.position) < StoppingDistance && (Vector2.Distance(transform.position, Player.position) > RetriatDistance))
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, Player.position) < RetriatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);
        }
    }
}
