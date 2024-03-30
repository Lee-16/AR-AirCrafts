using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5f;

    private void OnEnable()
    {
        SwipeControls.OnSwipe += HandleSwipe;
    }

    private void OnDisable()
    {
        SwipeControls.OnSwipe -= HandleSwipe;
    }

    void HandleSwipe(SwipeDirection direction)
    {
        switch (direction)
        {
            case SwipeDirection.Left:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
            case SwipeDirection.Right:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }
}
