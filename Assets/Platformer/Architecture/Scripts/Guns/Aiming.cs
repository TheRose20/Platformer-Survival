using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private void Update()
    {
        RotateGunToCursor();

    }

    private void RotateGunToCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnDrawGizmos()
    {
        int layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right, 50, layerMask);
        if (hit2D)
        {
            Gizmos.DrawSphere(hit2D.point, 0.1f);
            Gizmos.DrawRay(transform.position, transform.right * hit2D.distance);
        }
    }
}
