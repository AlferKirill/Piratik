using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHold : MonoBehaviour
{ 
    public bool hold;
    public float distance = 2;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject;


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!hold)
            {
                Physics2D.queriesHitTriggers = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null && hit.collider.tag == "Weapon")
                {
                    hold = true;
                }
            }
        }
        else
        {
            hold = false;

            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwObject;
            }
        }


        if(hold)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;

            if (holdPoint.position.x > transform.position.x && hold==true)
            {
                hit.collider.gameObject.transform.position = new Vector2(transform.localScale.x, transform.localScale.y);
            }
            else if (holdPoint.position.x < transform.position.x && hold == true)
            {
                hit.collider.gameObject.transform.position = new Vector2(transform.localScale.x * 2f, transform.localScale.y * 2f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);          
    }
}
