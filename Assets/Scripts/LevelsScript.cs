using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelsScript : MonoBehaviour {
    // Start is called before the first frame update
    void Awake () {
        for (int i = 1; i < 10; i++) {
            Debug.Log("Loading LEVELS "+i.ToString()+" COMLETE WITH STARS: "+GameManager.instance.getStarsForLevel(i).ToString());
            GameObject.Find("StarsPanelLV"+i).GetComponent<Image>().sprite = Resources.Load<Sprite>("stars"+GameManager.instance.getStarsForLevel(i).ToString());
            if (i > 1 && GameManager.instance.isEnabledLevel(i) == 0) {
                GameObject.Find("ButtonLV"+i).GetComponent<Button>().interactable = false;
                GameObject.Find("StarsPanelLV"+i).GetComponent<Image>().enabled = false;
            }
        }

        Debug.Log("ciaooo");

    
    }


    void Start() {
        Debug.Log("OPENED LEVELS! ");
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OpenLevelAtIndex(int levelNumber) {
        Debug.Log("OPENING LEVEL AT INDEX "+levelNumber);
        StartCoroutine(CorutineOpenLevel(levelNumber));
    }

    IEnumerator CorutineOpenLevel(int levelNumber) {
        yield return new WaitForSeconds(1);
        GameManager.instance.currentLevel = levelNumber;
        SceneManager.LoadScene(2);
    }

    public void OpenMenu() {
        StartCoroutine(CorutineOpenMenu());
    }
    IEnumerator CorutineOpenMenu() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}

