using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestVectors : MonoBehaviour
{
    public TMP_Text _text;
    public TMP_Text text2;
    public Transform target;

    //private Transform

    private void Start()
    {
        Vector2[] vectors = new Vector2[4];
        vectors[0] = Vector2.right;
        vectors[1] = Vector2.down;
        vectors[2] = Vector2.left;
        vectors[3] = Vector2.up;
        for (int i = 0; i < vectors.Length; i++)
        {
            Debug.Log(vectors[i]);
        }
        for (int i = 0; i < vectors.Length; i++)
        {
            Vector2 currentVector = Vector2.zero;
            if (i+1 >= vectors.Length)
            {
                currentVector = vectors[i] + vectors[0];
            }
            else
            {
                currentVector = vectors[i] + vectors[i+1];
            }
            Direction newEnum = new Direction();
            Debug.Log($"{newEnum}:{currentVector}");
        }
    }

    private void FixedUpdate()
    {
        //CheckTargetPath();

        Checker();

    }

    private void Checker()
    {
        Vector2 directionTarget = target.position - transform.position;
        float distanceTarget = Vector2.Distance(target.position, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionTarget, distanceTarget);

        if(hit.collider ==  target)
        {
            Debug.Log("Don't have obstacle");
        }
        else if(hit.collider != target)
        {

        }
    }

    private void CheckTargetPath()
    {
        Vector2 directionTarget = target.position - transform.position;
        Debug.DrawRay(transform.position, directionTarget);

        Vector2 alignedDirection = CalculateAlignedNormVector(directionTarget);

        float distanceTarget = Vector2.Distance(target.position, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, alignedDirection, distanceTarget);
        
        float distanceAligned = GetAlignedDistance(alignedDirection, directionTarget);
        Vector3 direction4Distance = alignedDirection * distanceAligned;
        if (hit == false)
        {
            Vector3 position = new Vector2(transform.position.x, transform.position.y) + alignedDirection * distanceAligned;
            RaycastHit2D hit2 = Physics2D.Raycast(position, target.position - position, Vector2.Distance(position, target.position));
            if(hit2.collider.transform == target.transform)
            {
                Debug.Log("Create path!");
            }
            Debug.DrawRay(position, target.position - position, Color.green);
        }
        else if(hit.collider.transform != target.transform)
        {

        }

        Debug.DrawRay(transform.position, direction4Distance, Color.red);
    }

    private static float GetAlignedDistance(Vector2 alignedDirection, Vector2 returnDirectionValue)
    {
        if (alignedDirection == Vector2.right) return returnDirectionValue.x;
        else if (alignedDirection == Vector2.down) return -returnDirectionValue.y;
        else if (alignedDirection == Vector2.left) return -returnDirectionValue.x;
        else if (alignedDirection == Vector2.up) return returnDirectionValue.y;
        else
        {
            Debug.LogError("Direction DOWN!");
            return 0;
        }
    }

    private static Vector2 CalculateAlignedNormVector(Vector2 direction)
    {
        float[] angels = new float[4];

        angels[0] = Vector2.Angle(direction, Vector2.right);
        angels[1] = Vector2.Angle(direction, Vector2.down);
        angels[2] = Vector2.Angle(direction, Vector2.left);
        angels[3] = Vector2.Angle(direction, Vector2.up);

        float min = angels[0];
        int minIndex = 0;
        for (int i = 0; i < angels.Length; i++)
        {
            float currentAngle = angels[i];
            if (currentAngle < min)
            {
                min = currentAngle;
                minIndex = i;
            }
        }

        switch (minIndex + 1)
        {
            case 0: return Vector2.right;
            case 1: return Vector2.down;
            case 2: return Vector2.left;
            case 3: return Vector2.up;
            default: return Vector2.zero;
        }
    }
/*
    private static Enum ConvertVectorEnum(Vector2 vector)
    {

    }
    private static Vector2 ConvertEnumVector(Direction directionEnum)
    {

    }
*/

    private void SetText(string text)
    {
        _text.text = text;
    }
}

public enum Direction
{
    right, 
    down,
    left,
    up
}
