using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float minDistanceForSwipe = 20f;

    public delegate void SwipeAction(SwipeDirection direction);
    public static event SwipeAction OnSwipe;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                if (OnSwipe != null)
                    OnSwipe(direction);
            }
            else
            {
                var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                if (OnSwipe != null)
                    OnSwipe(direction);
            }
            fingerUpPosition = fingerDownPosition;
        }
    }

    bool IsVerticalSwipe()
    {
        return VerticalMoveDistance() > HorizontalMoveDistance();
    }

    bool SwipeDistanceCheckMet()
    {
        return VerticalMoveDistance() > minDistanceForSwipe || HorizontalMoveDistance() > minDistanceForSwipe;
    }

    float VerticalMoveDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    float HorizontalMoveDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}
