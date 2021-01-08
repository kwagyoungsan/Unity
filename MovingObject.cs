﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public LayerMask layerMask;

    public float speed;
    protected Vector3 vector;
    public int walkCount;
    protected int currentWalkcount;
    public Animator animator;

    protected void Move(string _dir)
    {
        StartCoroutine(MoveCoroutine(_dir));
    }

    IEnumerator MoveCoroutine(string _dir)
    {
        vector.Set(0, 0, vector.z);

        switch (_dir)
        {
            case "UP":
                vector.y = 1f;
                break;
            case "DOWN":
                vector.y = -1f;
                break; 
            case "LEFT":
                vector.x = -1f;
                break;
            case "RIGHT":
                vector.x = 1f;
                break;
        }
        animator.SetFloat("DirX", vector.x);
        animator.SetFloat("DirY", vector.y);
        animator.SetBool("Walking", true);

        while (currentWalkcount < walkCount)
        {
            transform.Translate(vector.x * speed, vector.y * speed, 0);
            currentWalkcount++;
            yield return new WaitForSeconds(0.01f);
        }
        currentWalkcount = 0;
        animator.SetBool("Walking", false);
      
    }
}

