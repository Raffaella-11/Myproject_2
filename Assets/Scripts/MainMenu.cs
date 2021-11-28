using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    // Start is called before the first frame update
    public void PlayGame() {
        StartCoroutine(CorutineOpenNextLevel());
    }

    public void LevelsGame() {
        StartCoroutine(CorutineOpenLevels());
    }
    IEnumerator CorutineOpenLevels() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public void OpenCredits() {
        StartCoroutine(CorutineOpenCredits());
    }
    IEnumerator CorutineOpenCredits() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }
    IEnumerator CorutineOpenNextLevel() {
        yield return new WaitForSeconds(1);
        GameManager.instance.currentLevel = GameManager.instance.currentLevel + 1;
        SceneManager.LoadScene(4);
    }



    public void ToggleWordsC() {
        Debug.Log("Toggle C!");
        DeckManager.instance.ToggleWordsC();
    }
    public void ToggleWordsG() {
        Debug.Log("Toggle G!");
        DeckManager.instance.ToggleWordsG();
    }
    public void ToggleWordsSC() {
        Debug.Log("Toggle SC!");
        DeckManager.instance.ToggleWordsSC();
    }
}
