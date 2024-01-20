using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class SimpleShoot2 : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKeyCode = KeyCode.Mouse0;
    [SerializeField] private Gun _gun;

    public Vector3 MousePosition;

    private void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(_shootKeyCode))
        {
            _gun.TryShoot();
        }
    }

    private void OnValidate()
    {
        if (_gun == null)
        {
            _gun = GetComponent<Gun>();
        }
    }
}
