using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageStar
{
    public List<GameObject> starList;
}

public class SelectMenu : MonoBehaviour
{
    [SerializeField] private List<StageStar> stageStarList;

    public void SetStageStar()
    {
        for (int stage = 0; stage < ScoreData.stageStars.Length; stage++)
        {
            for (int star = 0; star < ScoreData.stageStars[stage]; star++)
            {
                stageStarList[stage].starList[star].SetActive(true);
            }
        }
    }

}
