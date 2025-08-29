using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchSystem : Singleton<MatchSystem>
{
    [SerializeField] private ScoreViewUI scoreViewUI;
    [SerializeField] private GameObject matchSFXPrefab;
    private int _scrore;

    private List<CircleView>[] _towers;
    private List<CircleView> _matches = new List<CircleView>();

    private bool _isMatch = false;

    public bool IsMatch => _isMatch;

    private void Start()
    {
        Setup();
        scoreViewUI.Setup();
        _scrore = 0;
    }

    public void AddCircleToTower(int towerIndex, CircleView circleView)
    {
        _towers[towerIndex].Add(circleView);

        CheckMatches();
    }

    public int GetCirclesCount()
    {
        int circlesCount = 0;

        for(int i = 0; i < _towers.Length; i++)
        {
            circlesCount += _towers[i].Count;
        }

        return circlesCount;
    }

    private void Setup()
    {
        _towers = new List<CircleView>[3];
        for (int i = 0; i < _towers.Length; i++)
        {
            _towers[i] = new List<CircleView>();
        }
    }

    private void CheckMatches()
    {
        CheckVerticalMatch();
        CheckHorizontalMatch();
        CheckDiagonalMatch();

        if(_isMatch)
        {
            Invoke("RemoveCircles", 0.5f);
        }

        GameOverSystem.Instance.CheckGameOver();
    }

    private void RemoveCircles()
    {
        for(int i = 0; i < _towers.Length; i++)
        {
            _towers[i].RemoveAll(circle => _matches.Contains(circle));
        }

        foreach(CircleView circleView in _matches)
        {
            Instantiate(matchSFXPrefab, circleView.transform.position, Quaternion.identity);
            Destroy(circleView.gameObject);
        }

        _matches.Clear();
        _isMatch = false;
    }

    private void CheckVerticalMatch()
    {
        for(int i = 0; i < 3; i++)
        {
            if (_towers[i].Count >= 3)
            {
                if (CheckMatch(_towers[i][0], _towers[i][1], _towers[i][2]))
                {
                    Match(_towers[i][0], _towers[i][1], _towers[i][2]);
                    _scrore += 10;
                    scoreViewUI.UpdateScoreText(_scrore);
                }
            }
        }
    }

    private void CheckHorizontalMatch()
    {
        if (_towers[0].Count >= 1 && _towers[1].Count >= 1 && _towers[2].Count >= 1)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_towers[0].Count > i && _towers[1].Count > i && _towers[2].Count > i)
                {
                    if (CheckMatch(_towers[0][i], _towers[1][i], _towers[2][i]))
                    {
                        Match(_towers[0][i], _towers[1][i], _towers[2][i]);
                        _scrore += 10;
                        scoreViewUI.UpdateScoreText(_scrore);
                    }
                }
            }
        }
    }

    private void CheckDiagonalMatch()
    {
        if (_towers[0].Count >= 1 && _towers[1].Count >= 2 && _towers[2].Count >= 3)
        {
            if (CheckMatch(_towers[0][0], _towers[1][1], _towers[2][2]))
            {
                Match(_towers[0][0], _towers[1][1], _towers[2][2]);
                _scrore += 10;
                scoreViewUI.UpdateScoreText(_scrore);
            }
        }

        if (_towers[2].Count >= 1 && _towers[1].Count >= 2 && _towers[0].Count >= 3)
        {
            if (CheckMatch(_towers[2][0], _towers[1][1], _towers[0][2]))
            {
                Match(_towers[2][0], _towers[1][1], _towers[0][2]);
                _scrore += 10;
                scoreViewUI.UpdateScoreText(_scrore);
            }
        }
    }

    private void Match(CircleView circleView1, CircleView circleView2, CircleView circleView3)
    {
        _matches.Add(circleView1);
        _matches.Add(circleView2);
        _matches.Add(circleView3);

        _isMatch = true;
    }

    private bool CheckMatch(CircleView circleView1, CircleView circleView2, CircleView circleView3)
    {
        if(circleView1.Circle.Color == circleView2.Circle.Color && circleView2.Circle.Color == circleView3.Circle.Color)
            return true;
        else 
            return false;
    }

    [ContextMenu("AddScore")]
    private void AddScoreTest()
    {
        _scrore += 10;
        scoreViewUI.UpdateScoreText(_scrore);
    }
}
