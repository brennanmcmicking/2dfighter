using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: freeze players on game end.

public class PlayerHandler : MonoBehaviour {
	public Rigidbody[] PlayerModels;
	
	public Text Player1StocksT;
	public Text Player2StocksT;
	public Text Player1PercentT;
	public Text Player2PercentT;
	
	public Text MainText;
	
	private int Player1Stocks;
	private int Player2Stocks;
	private float Player1Percent;
	private float Player2Percent;
	
	private PlayerTraits Player1Traits;
	private PlayerTraits Player2Traits;
	
	// Use this for initialization
	void Start () {
		PlayerModels[0].position = new Vector3(-5, 2, 0);
		PlayerModels[1].position = new Vector3( 5, 2, 0);
		MainText.text = "";
		
		Player1Stocks = 4;
		Player2Stocks = 4;
		Player1Percent = 0.0f;
		Player2Percent = 0.0f;
		Player1StocksT.text = "Lives: " + Player1Stocks;
		Player2StocksT.text = "Lives: " + Player2Stocks;
		
		Player1Traits = GameObject.Find ("Player1").GetComponent<PlayerTraits> ();
		Player2Traits = GameObject.Find ("Player2").GetComponent<PlayerTraits> ();
		StartCoroutine(DisplayGo());
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Rigidbody RB in PlayerModels) {
			if (RB.position.x > 15 || RB.position.x < -15 || RB.position.y < -5 || RB.position.y > 10) {
				RB.velocity = Vector3.zero;
				RB.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
				int PlayerNumber = RB.GetComponent<PlayerTraits> ().PlayerNumber;
				if (PlayerNumber == 1) {
					Player1Stocks -= 1;
					Player1StocksT.text = "Lives: " + Player1Stocks;
					if (Player1Stocks > 0) {
						Player1PercentT.text = "0%";
						Player1Traits.Percent = 1.0f;
					} else {
						MainText.color = Color.blue;
						MainText.text = "Player 2 wins!";
						PlayerModels[0].constraints = RigidbodyConstraints.FreezeAll;
						PlayerModels[1].constraints = RigidbodyConstraints.FreezeAll;
					}
				}
				
				if (PlayerNumber == 2) {
					Player2Stocks -= 1;
					Player2StocksT.text = "Lives: " + Player2Stocks;
					if (Player2Stocks > 0) {
						Player2PercentT.text = "0%";
						Player2Traits.Percent = 1.0f;
					} else {
						MainText.color = Color.red;
						MainText.text = "Player 1 wins!";
						PlayerModels[0].constraints = RigidbodyConstraints.FreezeAll;
						PlayerModels[1].constraints = RigidbodyConstraints.FreezeAll;
					}
				}
				
			}
		}
	}
	
	public void UpdatePercent () {
		Player1PercentT.text = Player1Traits.Percent + "%";
		Player2PercentT.text = Player2Traits.Percent + "%";
	}
	
	IEnumerator DisplayGo () {
		MainText.color = Color.yellow;
		MainText.text = "Go!";
		yield return new WaitForSeconds(1);
		MainText.text = "";
	}
}