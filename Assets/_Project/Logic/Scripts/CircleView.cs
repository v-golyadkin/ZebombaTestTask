using UnityEngine;

public class CircleView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    public Circle Circle { get; private set; }

    public void Setup(Circle circle)
    {
        Circle = circle;
        sprite.color = circle.Color;
    }
}
