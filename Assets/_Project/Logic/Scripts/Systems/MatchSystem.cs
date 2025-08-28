using System.Collections.Generic;
using UnityEngine;

public class MatchSystem : Singleton<MatchSystem>
{
    private List<CircleView>[] towers;

    private void Start()
    {
        Setup();
    }

    public void AddCircleToTower(int towerIndex, CircleView circleView)
    {
        towers[towerIndex].Add(circleView);

        CheckMatches();
    }

    private void Setup()
    {
        towers = new List<CircleView>[3];
        for (int i = 0; i < towers.Length; i++)
        {
            towers[i] = new List<CircleView>();
        }
    }

    private void CheckMatches()
    {
        CheckVerticalMatch();
        CheckHorizontalMatch();
        CheckDiagonalMatch();
    }

    private void CheckVerticalMatch()
    {
        for(int i = 0; i < 3; i++)
        {
            if (towers[i].Count >= 3)
            {
                if (CheckMatch(towers[i][0], towers[i][1], towers[i][2]))
                {
                    Debug.Log("VERTICAL MATCH!!!");
                    //TO DO REMOVE MATCH CIRCLE
                    //TO DO ADD SCORE FOR MATCH
                    //TO DO CREATE VFX
                }
            }
        }
    }

    private void CheckHorizontalMatch()
    {
        if (towers[0].Count >= 1 && towers[1].Count >= 1 && towers[2].Count >= 1)
        {
            for (int i = 0; i < 3; i++)
            {
                if (towers[0].Count > i && towers[1].Count > i && towers[2].Count > i)
                {
                    if (CheckMatch(towers[0][i], towers[1][i], towers[2][i]))
                    {
                        Debug.Log("HORIZONTAL MATCH!!!");
                        //TO DO REMOVE MATCH CIRCLE
                        //TO DO ADD SCORE FOR MATCH
                        //TO DO CREATE VFX
                    }
                }
            }
        }
    }

    private void CheckDiagonalMatch()
    {
        if (towers[0].Count >= 1 && towers[1].Count >= 2 && towers[2].Count >= 3)
        {
            if (CheckMatch(towers[0][0], towers[1][1], towers[2][2]))
            {
                Debug.Log("DIAGONAL MATCH!!!");
                //TO DO REMOVE MATCH CIRCLE
                //TO DO ADD SCORE FOR MATCH
                //TO DO CREATE VFX
            }
        }

        if (towers[2].Count >= 1 && towers[1].Count >= 2 && towers[0].Count >= 3)
        {
            if (CheckMatch(towers[2][0], towers[1][1], towers[0][2]))
            {
                Debug.Log("DIAGONAL MATCH!!!");
                //TO DO REMOVE MATCH CIRCLE
                //TO DO ADD SCORE FOR MATCH
                //TO DO CREATE VFX
            }
        }
    }

    private bool CheckMatch(CircleView circleView1, CircleView circleView2, CircleView circleView3)
    {
        if(circleView1.Circle.Color == circleView2.Circle.Color && circleView2.Circle.Color == circleView3.Circle.Color)
            return true;
        else 
            return false;
    }
}
