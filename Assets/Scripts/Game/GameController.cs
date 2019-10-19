using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public delegate void OnTaggedChange(string newTagged);

    public event OnTaggedChange onTaggedChange;
    [SerializeField] Canvas EndCanvas;
    public Text score1, score2, score3,score4, ganador;
    [SerializeField]
    private float playTime = 60F;
    
    [SerializeField]
    private int playerCount = 4;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private bool instantiateHumanPlayer = true;
    private GameObject[] listaJugadores;
    private Dictionary<string, int> taggedScore = new Dictionary<string, int>();

    public string GetWinner()
    {
        return string.Empty;
    }
    private void Update()
    {
        Debug.Log(listaJugadores[0].GetComponent<PlayerController>().IsTagged + " , " + listaJugadores[1].GetComponent<PlayerController>().IsTagged + " , " + listaJugadores[2].GetComponent<PlayerController>().IsTagged + " , " + listaJugadores[3].GetComponent<PlayerController>().IsTagged);
    }
    // Start is called before the first frame update
    private void Start()
    {

        PlayerController.onTaggedChange += UpdateTaggedScore;

        onTaggedChange += UpdateTaggedScore;
        if (playerCount > 4) playerCount = 4;
        taggedScore.Clear();
        listaJugadores= new GameObject[playerCount];
        for (int i = 0; i < playerCount; i++)
        {
            string prefabPath = i == 0 && instantiateHumanPlayer ? "HumanPlayer" : "AIPlayer";

            GameObject playerInstance = Instantiate(Resources.Load<GameObject>(prefabPath),new Vector3(Random.Range(-22,22),0, Random.Range(-26,20)),Quaternion.identity);
            playerInstance.name = string.Format("Player{0}", i + 1);
            listaJugadores[i] = playerInstance;
            taggedScore.Add(playerInstance.name, 0);
        }
        chooseRandomTaggedPlayer();
        
        Invoke("EndGame", playTime);
    }

    private void EndGame()
    {
        float points = 100;

        string winner;
        for (int i =0; i< taggedScore.Count;i++)
        {
            
            string player = "Player" + (i+1).ToString() ;
            if(taggedScore[player]<points) {
                points = taggedScore[player];
                winner = player;
                ganador.text = winner;
            }

        }
       
     
        EndCanvas.enabled = true;
        
        Debug.Log("EndGame");
        onTaggedChange -= UpdateTaggedScore;
    }

    private void UpdateTaggedScore(string newTaggedPlayer)
    {
        taggedScore[newTaggedPlayer] += 1;
        if(listaJugadores.Length==2)
        {

            score1.text = taggedScore["Player1"].ToString();
            score2.text = taggedScore["Player2"].ToString();
        }
        if (listaJugadores.Length == 3)
        {

            score1.text = taggedScore["Player1"].ToString();
            score2.text = taggedScore["Player2"].ToString();
            score3.text = taggedScore["Player3"].ToString();
        }
        if (listaJugadores.Length == 4)
        {

            score1.text = taggedScore["Player1"].ToString();
            score2.text = taggedScore["Player2"].ToString();
            score3.text = taggedScore["Player3"].ToString();
            score4.text = taggedScore["Player4"].ToString();
        }

    }
    private void chooseRandomTaggedPlayer()
    {

        listaJugadores[Random.Range(0, playerCount)].GetComponent<PlayerController>().IsTagged = true ;
        Debug.Log(listaJugadores[0].GetComponent<PlayerController>().IsTagged);

        Debug.Log(listaJugadores[1].GetComponent<PlayerController>().IsTagged);

    }
    public GameObject GetCurrentTagged()
    {
        int index=0;
        for(int i=0; i<listaJugadores.Length; i++)
        {
            if(listaJugadores[i].GetComponent<PlayerController>().IsTagged)
            {
                index = i;
                
            }
        }
        return listaJugadores[index];
    }
}