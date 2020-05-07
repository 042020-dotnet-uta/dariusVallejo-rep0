using System;
using System.Collections;
using System.Collections.Generic;

namespace RPS
{
    public class Player{
        public string name;
        public int score = 0;
        public Player(string name){
            this.name=name;
        }
 
    }
    class Program
    {
        static void Main(string[] args)
        {
             int RoundNumber=1;
             int ties=0;
             List<string> roundResuelt = new List<string>();
             string player1CurntRound, player2CurntRound;
             Console.WriteLine("Enter Player one name");
             Player player1 = new Player(Console.ReadLine());
             Console.WriteLine("Enter Player two name");
             Player player2 = new Player(Console.ReadLine());
             while(player1.score !=2 && player2.score !=2){
                 player1CurntRound =  RPSGenerator();
                 player2CurntRound =  RPSGenerator();
                 if(player1CurntRound == "rock"){
                    if(player2CurntRound == "paper"){
                     roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose rock, {player2.name} chose paper. - Player2 won");
                     player2.score++;
                    }else if(player2CurntRound == "scissor"){
                     roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose rock, {player2.name} chose scissor. - Player1 won");
                     player1.score++;                        
                    }else {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose rock, {player2.name} chose rock. - it is a ties");
                        ties++;
                    }
                 }else if(player1CurntRound == "paper"){
                    if(player2CurntRound == "rock"){
                     roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose paper, {player2.name} chose rock. - Player1 won");
                     player1.score++;
                    }else if(player2CurntRound == "scissor"){
                     roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose paper, {player2.name} chose scissor. - Player2 won");
                     player2.score++;                        
                    }else {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose paper, {player2.name} chose paper. - it is a ties");
                        ties++;
                    }
                 }else {
                    if(player2CurntRound == "rock"){
                     roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose scissor, {player2.name} chose paper. - Player1 won");
                     player1.score++;
                    }else if(player2CurntRound == "scissor"){
                     roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose scissor, {player2.name} chose rock. - Player2 won");
                     player2.score++;                        
                    }else {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose scissor, {player2.name} chose scissor. - it is a ties");
                        ties++;
                    }
                 }
                 RoundNumber++;
             }
             for(int i =0;i<roundResuelt.Count;i++){
                 Console.WriteLine(roundResuelt[i]);
             }
             if(player1.score == 2){
                 Console.WriteLine($"{player1.name} wins 2-{player2.score} with {ties} ties.");
             }else{
                 Console.WriteLine($"{player2.name} wins 2-{player1.score} with {ties} ties.");
             }
        }
            static string RPSGenerator(){
            Random rnd = new Random();
            int rundomNum  = rnd.Next(3);
            switch(rundomNum){
                case 0:
                    return "rock";
                    
                case 1:
                    return "paper";
                    
                case 2:
                    return  "scissor";
                default:
                    return "Default case";
            }
        } 
    }
}
