using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followPlayer : MonoBehaviour
{

    public Transform target;
    NavMeshAgent nav;
    public Animator _animator;

    public Vector3 position_;
    void Start()
    {
       _animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

        position_ = transform.position;

    }


    public bool inRange;
    private void FixedUpdate()
    {              
       if(inRange)
        {
            nav.SetDestination(target.position);
            _animator.SetInteger("anim", 1);
        }
        else
        {
            _animator.SetInteger("anim", -1);
            nav.SetDestination(position_);
        }
        if(position_ == transform.position)
        {
            _animator.SetInteger("anim", 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;


        }
    }
}
