using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public bool IsOnWall { get; private set; }
    //public bool IsGrounded { get; private set; }
    //public bool IsJumping { get; private set; }

    [SerializeField] private BallJumper _ballJumper;

    private string _tagWallString = "Wall";
    private string _tagFloorString = "Floor";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tagWallString))
        {
            IsOnWall = true;
        }
        if (collision.gameObject.CompareTag(_tagFloorString))
        {
            IsOnWall = false;
            //IsGrounded = true;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (IsOnWall)
    //    {
    //        if (_ballJumper.IsGrounded)
    //        {
    //            IsJumping = false;
    //        }
    //    }
    //}
}
