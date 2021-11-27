using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public int currentLevel = -1;

    void Awake () {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }

        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        


        instance = this; 
        DontDestroyOnLoad(this.gameObject);

    }


    public void setLevelStatisticsWithStars(int level, int stars) {
        // aggiorno il numero di stelle solo se ho fatto meglio della volta precedente

        Debug.Log("Setting level complete "+level.ToString()+" with stars: "+stars.ToString());


        if (getStarsForLevel(level) > stars) {
            setStarsForLevel(level, stars);
        }
        
        PlayerPrefs.SetInt("LevelManagerL"+level.ToString()+"_stars", currentLevel);
    }

    public void setStarsForLevel(int level, int stars) {
        PlayerPrefs.GetInt("LevelManagerL"+level.ToString()+"_stars", stars);
        PlayerPrefs.Save();
    }
    public int getStarsForLevel(int level) {
        int stars = PlayerPrefs.GetInt("LevelManagerL"+level.ToString()+"_stars", 0);
        return stars;
    }

    public void setEnabledLevel(int level) {
        PlayerPrefs.SetInt("LevelManagerL"+level.ToString()+"_enabled", 1);
    }
    public int isEnabledLevel(int level) {
        int stars = PlayerPrefs.GetInt("LevelManagerL"+level.ToString()+"_enabled", 0);
        return stars;
    }

    public void syncLevelData() {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }
}
