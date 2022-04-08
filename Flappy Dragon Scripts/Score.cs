using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score: MonoBehaviour
{
    public static int GetHighscore()//public static allows for use in other classes without creating an instance of this class
    {
        return PlayerPrefs.GetInt("highscore"); //Gets highscore from PlayerPrefs
    }


    public static bool TrySetNewHighscore(int score)//sets highscore in playerPrefs if the current score is higher than the score
    {
        int currentHighscore = GetHighscore();
        if (score > currentHighscore)
        {
            SoundManager.PlaySound(SoundManager.Sound.NewHighscore);
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void ResetHighscore()//use for debuggin purposes only, can instead Clear All PlayerPrefs in Unity under Edit
    {
        PlayerPrefs.SetInt("highscore", 0);
        PlayerPrefs.Save();
    }

}
