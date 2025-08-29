using System.Collections.Generic;
using UnityEngine;

public class CircleCreator : Singleton<CircleCreator>
{
    [SerializeField] private CircleView circleViewPrefab;

    private List<Color> colorList = new List<Color>() { Color.green, Color.blue, Color.yellow };

    public CircleView CreateCircleView(Vector3 position, Quaternion rotate, Transform parent)
    {
        Circle circle = new(GetRandomColor());
        CircleView circleView = Instantiate(circleViewPrefab, position, rotate, parent);
        circleView.Setup(circle);
        return circleView;
    }

    private Color GetRandomColor()
    {
        var randomColor = colorList[Random.Range(0, colorList.Count)];
        return randomColor;
    }
}
