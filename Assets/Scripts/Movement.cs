using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public MeshCollider coll;
    public float moveSpeed = 0.1f;
    public float jumpStrength = 1;

    void Update()
    {
        GetLateralMovement();
        GetJumpInput();
    }

    private void GetLateralMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            TurnAndMove(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            TurnAndMove(-Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            TurnAndMove(Vector3.right);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            TurnAndMove(-Vector3.right);
        }
    }

    /// <summary>
    /// Sets the forward vector of this gameobject to a vector, then moves forward.
    /// </summary>
    /// <param name="dirToFace"></param>
    private void TurnAndMove(Vector3 dirToFace)
    {
        transform.forward = dirToFace;
        transform.Translate(Vector3.forward * moveSpeed);
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce((transform.TransformDirection(Vector3.forward) + Vector3.up) * jumpStrength);
        }
    }

    private bool IsGrounded()
    {
        //Thanks to http://answers.unity.com/answers/196395/view.html for this!
        return Physics.Raycast(transform.position, -Vector3.up, coll.bounds.extents.y + 0.05f);
    }
}
