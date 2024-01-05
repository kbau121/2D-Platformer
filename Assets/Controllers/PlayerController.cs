using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static int IGNORE_RAYCAST;

    private new Rigidbody2D rigidbody;

    private bool isGrounded = false;
    private float groundedThreshold = 0.1f;

    /// <summary>
    /// Occurs before the first <see cref="Update()"/>, handles any information passing needed at the start
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// Occurs every frame
    /// </summary>
    private void Update()
    {
        updateGrounded();
    }

    /// <summary>
    /// Initializes state variables
    /// </summary>
    private void Awake()
    {
        IGNORE_RAYCAST = LayerMask.NameToLayer("Ignore Raycast");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Updates whether or not the player is on the ground depending on <see cref="groundedThreshold"/>
    /// </summary>
    private void updateGrounded()
    {
        int originalLayer = gameObject.layer;
        gameObject.layer = IGNORE_RAYCAST;

        isGrounded = Physics2D.Raycast(transform.position + (Vector3.down * transform.localScale.y * 0.5f), Vector2.down, groundedThreshold);

        gameObject.layer = originalLayer;
    }

    /// <summary>
    /// Displays visual debug information
    /// </summary>
    private void OnDrawGizmos()
    {
        // Draws the vector used to test if the player is grounded
        // Green -> isGrounded = True
        // Blue  -> isGrounded = False
        Gizmos.color = isGrounded ? Color.green : Color.blue;
        Gizmos.DrawRay(transform.position + (Vector3.down * transform.localScale.y * 0.5f), Vector3.down * groundedThreshold);
    }
}
