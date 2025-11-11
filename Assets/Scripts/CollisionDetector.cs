using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private BallJumper _ballJumper;
    public bool IsOnWall { get; private set; }
    public bool IsGrounded { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
            RollingOnWall();
        if (collision.gameObject.GetComponent<Ground>())
            RollingOnGround();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
            RollingOnWall();
        if (collision.gameObject.GetComponent<Ground>())
            RollingOnGround();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
            Falling();
        if (collision.gameObject.GetComponent<Ground>())
            Falling();
    }

    private void RollingOnGround()
    {
        IsOnWall = false;
        IsGrounded = true;
    }

    private void RollingOnWall()
    {
        IsOnWall = true;
        IsGrounded = false;
    }

    private void Falling()
    {
        IsOnWall = false;
        IsGrounded = false;
    }
}
