using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeckManager : MonoBehaviour
{

	public static DeckManager instance;
    public Card[] deck;
	private string[] Names_hard= new string[52]{"caffe", "cane", "cappello", "caraffa", "case", "castagna", "cavalli", "cavi", "chela", "chiave", "chiavi", "chiodi", "chitarra", "coccinella", "coccodrillo",  "coda",  "collo",  "colombo",  "corda",  "corvo",  "cozza",  "cuccia", "cuore", "cuscino", "gallina", "gambe", "gambero", "gambo", "ganci", "gatto", "ghepardo", "gheriglio", "ghiacciolo", "ghiande", "ghiro", "gobba", "gomitolo", "gomme", "gorilla", "gregge", "guanto", "gufo", "guinzaglio", "scacchiera", "scarpe", "scatola", "scheletro", "schiuma", "scoiattolo", "scopa", "scorpione", "scudo"};
	private string[] Names_soft= new string[21]{"cellula", "cerotto", "cervello", "ciabatta","cicogna", "cielo", "cigno", "cinghiale", "cintura",  "cipolla", "gelato", "gemelli", "gengiva", "genio", "gigante", "ginocchio", "giraffa", "gnomi", "sceriffo", "sciarpa", "scimmia"};
	
	void Awake () {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }

        instance = this; 
        DontDestroyOnLoad(this.gameObject);
    }
	
    // Start is called before the first frame update
    void Start(){
	    
        deck = new Card[73];
		int index=0;
		for (int i=0; i<21; i++){
			Card temp = new Card();
			temp.idx = index;
			temp.name = Names_soft[i];
			temp.soft = true;
			temp.IsC = Names_soft[i].StartsWith("c");
			temp.IsG = Names_soft[i].StartsWith("g");
			temp.IsSc = Names_soft[i].StartsWith("sc");
			temp.artwork = Resources.Load<Sprite>(temp.name);
            deck[index] = temp;
            index++;
            //Debug.Log(Names_soft[i].StartsWith("c");
		}	
		for (int i=0; i<52; i++){
			Card temp = new Card();
			temp.idx = index;
			temp.name = Names_hard[i];
			temp.soft = false;
			temp.IsC = Names_hard[i].StartsWith("c");
			temp.IsG = Names_hard[i].StartsWith("g");
			temp.IsSc = Names_hard[i].StartsWith("sc");
			temp.artwork = Resources.Load<Sprite>(temp.name);
			deck[index] = temp;
			index++;
			//Debug.Log(Names_hard[i].StartsWith("c");
		}
    }

    

    public void Shuffle()
    {
	    int replacements = UnityEngine.Random.Range(100, 1000);
	    for (int i=0; i< replacements; i++){
		    int A = UnityEngine.Random.Range(0, 34);
		    int B = UnityEngine.Random.Range(0, 34);

		    Card a = deck[A];
		    Card b = deck[B];
		    Card c = deck[A];

		    a = b;
		    b = c;

		    deck[A] = a;
		    deck[B] = b;
	    }
}


	
	
}

[Serializable]
public class Card
{
	public int idx;
   	public string name; 
	public bool soft;
	public Sprite artwork;
	public bool IsC;
	public bool IsG;
	public bool IsSc;

}



