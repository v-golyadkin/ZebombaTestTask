using UnityEngine;

public class CircleDetector : MonoBehaviour
{
    [SerializeField] private int detectorID;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var circleView = collider.GetComponent<CircleView>();
        if (circleView != null)
        {
            MatchSystem.Instance.AddCircleToTower(detectorID, circleView);
        }
    }
}
