using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/*
 * Using MINIMAX Algorithm (aka Alpha Beta or MIN-MAX)
 * credit to squidarth
 * https://github.com/squidarth/ChessAI
 */

public class AI : MonoBehaviour {

	private static int DEPTH = 1;
	private int numTurns;

	public GameManager manager;
	private PlayerController human,bot;
	private Text timer;

	void Start(){
		human = manager.player1;
		bot = manager.player2;
		timer = manager.timer;
	}

	// Update is called once per frame
	void Update () {
		if (timer.text == "2") {
			bot.triggerMove(makeMove (manager));
		}
	}

	protected int makeMove(GameManager manager){

		//preparing
		int bestMove = 3;
		int bestMoveScore;

		List<GameManager> possibilities = new List<GameManager>();
		List<int> moves = new List<int>();

		//generate all possible moves
		/*
		 * 1 = attack
		 * 2 = defend
		 * 3 = charge
		 * 4 = super attack
		 */
		for (int i = 1; i <= 4; i++) {
			for (int j = 1; j <= 4; j++) {
				//check that move is legal
				if( isLegal(bot,i) && isLegal(human,j)){
					moves.Add (i);

					//simulate result
					GameManager result = Instantiate(manager);
					PlayerController tmp_human = Instantiate(result.player1);
					PlayerController tmp_bot = Instantiate(result.player2);
					result.player1 = tmp_human;
					result.player2 = tmp_bot;
					result.player1.triggerMove (j);
					result.player2.triggerMove (i);
					result.battle ();

					possibilities.Add (result);
				}
			}
		}

		//start min max algorithm
		bestMove = moves.ElementAt(0);
		bestMoveScore = evaluateMove (possibilities.First (), int.MinValue, int.MaxValue, DEPTH,false);

		for (int i = 1; i < possibilities.Count; i++) {
			int j = evaluateMove (possibilities.ElementAt (i), int.MinValue, int.MaxValue, DEPTH,false);
			if (j >= bestMoveScore) {
				bestMove = moves.ElementAt (i);
				bestMoveScore = j;
			}
		}

		return bestMove;
	}

	private int evaluateMove(GameManager possibility, int alpha, int beta, int depth,bool player){
		//weight value will be return when depth reach 0
		if (depth == 0) {
			int evaluation = evaluate (possibility);
			return evaluation;
		}
		if (player == false) {

			//repeat process in makeMove()
			List<int> moves_bot = new List<int>(), moves_human = new List<int>();
			PlayerController human = possibility.player1;
			PlayerController bot = possibility.player2;

			for (int i = 1; i <= 4; i++) {
				for (int j = 1; j <= 4; j++) {
					if (isLegal (bot, i) && isLegal (human, j)) {
						moves_bot.Add (i);
						moves_human.Add (j);
					}
				}
			}

			int newBeta = beta;
			foreach (int move_bot in moves_bot) {
				foreach (int move_human in moves_human) {
					//simulate result
					GameManager result = Instantiate(possibility);
					PlayerController tmp_human = Instantiate(possibility.player1);
					PlayerController tmp_bot = Instantiate(possibility.player2);
					result.player1 = tmp_human;
					result.player2 = tmp_bot;
					result.player1.triggerMove (move_human);
					result.player2.triggerMove (move_bot);
					result.battle ();

					newBeta = Mathf.Min (newBeta, evaluateMove (result, alpha, beta, depth - 1, !player));
					if (newBeta <= alpha)
						break;
				}
			}
			return newBeta;
		} else {
			//repeat process in makeMove()
			List<int> moves_bot = new List<int>(), moves_human = new List<int>();
			//this code is copied from above but switch bot and human
			PlayerController human = possibility.player2;
			PlayerController bot = possibility.player1;

			for (int i = 1; i <= 4; i++) {
				for (int j = 1; j <= 4; j++) {
					if (isLegal (bot, i) && isLegal (human, j)) {
						moves_bot.Add (i);
						moves_human.Add (j);
					}
				}
			}

			int newAlpha = alpha;
			foreach (int move_bot in moves_bot) {
				foreach (int move_human in moves_human) {
					//simulate result
					GameManager result = Instantiate(possibility);
					PlayerController tmp_human = Instantiate(possibility.player1);
					PlayerController tmp_bot = Instantiate(possibility.player2);
					result.player1 = tmp_human;
					result.player2 = tmp_bot;
					result.player1.triggerMove (move_human);
					result.player2.triggerMove (move_bot);
					result.battle ();

					newAlpha = Mathf.Max (newAlpha, evaluateMove (result, alpha, beta, depth - 1, !player));
					if (beta <= newAlpha)
						break;
				}
			}
			return newAlpha;
		}
	}

	private int evaluate(GameManager manager){
		int humanScore = 0, botScore = 0;
		PlayerController human = manager.player1;
		PlayerController bot = manager.player2;

		humanScore += human.hp * 3;
		humanScore += human.mp * 1;

		botScore += bot.hp * 3;
		botScore += bot.mp * 1;

		return botScore - humanScore;
	}

	private bool isLegal(PlayerController player, int move){
		if (move == 1 && player.mp < 1)
			return false;
		else if (move == 4 && player.mp < 3)
			return false;
		else
			return true;
	}
}
