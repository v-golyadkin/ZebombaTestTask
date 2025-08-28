using UnityEngine;

public class CircleCreator : Singleton<CircleCreator>
{
    [SerializeField] private CircleView circleViewPrefab;

    public CircleView CreateCircleView(Vector3 position, Quaternion rotate, Transform parent)
    {
        Circle circle = new(Color.yellow);
        CircleView circleView = Instantiate(circleViewPrefab, position, rotate, parent);
        circleView.Setup(circle);
        return circleView;
    }
}
