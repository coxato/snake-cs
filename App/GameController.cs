using System;
using System.Collections.Generic;
using static System.Console;
using static System.Threading.Thread;
using static snake_cs.Utils.Utils;
using snake_cs.GameObjects;


namespace snake_cs.App
{
    public class GameController
    {
        Board board;
        Snake snake;
        int intervalTime = 500;
        // arrow keys
        ConsoleKey direction = ConsoleKey.RightArrow;
        // can continue play
        bool CanPlay = true;


        public GameController(){
            makeGame();
        }


        // init board, snake and print first time
        private void makeGame(){
            // init props
            board = new Board(15, 20, '.');
            var (iPos, jPos) = randomBoardPosition(15, 20);
            snake = new Snake(iPos, jPos);
        }


        // read key and save in direction prop
        public void savePressedKey(){
            if(Console.KeyAvailable){
                ConsoleKeyInfo cki;
                cki = ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.RightArrow:
                        // don't eat himself
                        if(direction != ConsoleKey.LeftArrow)  direction = ConsoleKey.RightArrow;
                        break;
                    case ConsoleKey.LeftArrow:
                        if(direction != ConsoleKey.RightArrow) direction = ConsoleKey.LeftArrow;
                        break;
                    case ConsoleKey.UpArrow:
                        if(direction != ConsoleKey.DownArrow)  direction = ConsoleKey.UpArrow;
                        break;
                    case ConsoleKey.DownArrow:
                        if(direction != ConsoleKey.UpArrow)    direction = ConsoleKey.DownArrow;
                        break;
                    default:
                        break;
                }
            }
        }


        // get next position of snake depends the actual direction
        private (int, int) calculateNextHeadPosition(){
            SnakePart head = snake.SnakeBodyParts[0];
            var (iPos, jPos) = head;

            // next i j snake positions in board.
            // almost like a plain object in JavaScript.
            Dictionary<int, (int, int)> places = new Dictionary<int, (int, int)>();
            places.Add(37, (iPos, jPos - 1) ); // left
            places.Add(38, (iPos - 1, jPos) ); // up
            places.Add(39, (iPos, jPos + 1) ); // right
            places.Add(40, (iPos + 1, jPos) ); // down

            return places[(int)direction]; 
        }


        // calculate and manage the next snake head collitions in the board
        private (int, int) calculateNextHeadCollition(){

            var (iPos, jPos) = calculateNextHeadPosition();
            try
            {
                // what have the board in the next position
                char characterInNextPosition = board.getCharacterInPositions(iPos, jPos);
                
                if(characterInNextPosition == '$'){
                    manageFoodCollition();
                }
                else if(characterInNextPosition == '#'){
                    manageSelfCollition();
                }

            }
            catch (System.IndexOutOfRangeException)
            {
                manageOutBoardCollition();
            }

            return (iPos, jPos);
        }


        // ========== manage snake collitions ==========

        private void manageOutBoardCollition(){
            WriteLine("You hit the wall, sorry you loose :(");
            CanPlay = false;
        }

        private void manageFoodCollition(){
            board.useItem("food");
            snake.addPart();
        }

        private void manageSelfCollition(){
            WriteLine("Ups, you ate yourself :(");
            CanPlay = false;
        }

        // ========== end collitions ==========


        // update the board and snake
        public void update(){
            
            var (newIPos , newJPos) = calculateNextHeadCollition();

            if(CanPlay){
                snake.update(newIPos, newJPos);
                board.update(snake);
            }

        }


        public void play(){
            // print first time
            board.update(snake, true);
            Sleep(intervalTime);

            while(true){
                if(CanPlay){
                    savePressedKey();
                    update();
                    Sleep(intervalTime);
                }
                else{
                    WriteLine("thanks for play :)");
                    break;
                }
            }
        }

    }
}