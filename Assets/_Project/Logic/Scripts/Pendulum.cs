using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float swingSpeed = 1.5f;
    [SerializeField] private Transform circleHolder;

    private float _currentAngle;
    private CircleView _currentCircleView;
    private float _swingAmplitudeAngle = 45f;
    private bool _isSwinging = true;

    private void Start()
    {
        CreateNewCircle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReleaseCircle();
        }
    }

    private void FixedUpdate()
    {
        _currentAngle = _swingAmplitudeAngle * Mathf.Sin(Time.time * swingSpeed);
        transform.rotation = Quaternion.Euler(0, 0, _currentAngle);
    }

    private void CreateNewCircle()
    {
        if(_currentCircleView != null) return;

        _currentCircleView = CircleCreator.Instance.CreateCircleView(circleHolder.position, Quaternion.identity, circleHolder);
        _isSwinging = true;
    }

    private void ReleaseCircle()
    {
        if(_currentCircleView == null && !_isSwinging) return;

        _isSwinging = false;

        _currentCircleView.transform.SetParent(null);

        var rb = _currentCircleView.GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        _currentCircleView = null;

        Invoke("CreateNewCircle", 1f);
    }
}
