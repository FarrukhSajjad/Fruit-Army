using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVel = 0.1f;

    private Vector3 lastMousePosition;

    private Vector3 mouseVel;

    private Collider2D collider;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        SetBladePosition();
        collider.enabled = IsMouseMoving();
    }

    private void SetBladePosition()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private bool IsMouseMoving()
    {
        Vector3 mouseMoving = transform.position;
        float travelled = (lastMousePosition - mouseMoving).magnitude;

        lastMousePosition = mouseMoving;

        if (travelled > minVel)
        {
            return true;
        }
        else {
            return false;
        }
    }
}
