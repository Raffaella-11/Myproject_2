using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneScript : MonoBehaviour {
    // Start is called before the first frame update
    


    public int _levelID = 0;
    public int _levelPreviusScore = 0; // sul JSON salviamo solo lo score precedente; alla fine del gioco il currentScore sovrascrive il previousScore
    public int _levelCurrentScore = 0;
    public int _worldID = 0; // L'id del mondo/modalità è usato anche per trovare lo sfondo legato a quella modalità (EX. mondo facile: world_background_1.png ...)
    public int _currentWordIndex = 0; // va da 0 a 9 e la usiamo per ottenere la parola corrente nel livello corrente nel mondo corrente



    public string[] words;


    void Awake () {
        _levelID = GameManager.instance.currentLevel;
        _levelPreviusScore = GameManager.instance.getStarsForLevel(_levelID);
    }



    void Start() {
        // GameManager.AnyLevel.lives
        Debug.Log("OPENED LEVEL SPECIAL! " + _levelID.ToString() + " - ");
    }

    // Update is called once per frame
    void Update() {
        
    }



    public void OpenNextLevel() {
        Debug.Log("OPENING NEXT LEVEL! ");
        //anotherScript.PrepareLevel(levelNumber);
        GameManager.instance.setLevelStatisticsWithStars(_levelID, _levelCurrentScore);
        if (_levelCurrentScore > 1) {
            GameManager.instance.currentLevel = GameManager.instance.currentLevel+1;
        } else {
            Debug.Log("Gioco non superato! Riprova ");
        }
        SceneManager.LoadScene(2);
    }
}
