using static System.Console;
using System.Collections.Generic;
// my entities
using snake_cs.Utils;

namespace snake_cs.GameObjects
{
    public class Board
    {
        public int Rows;
        public int Collumns;
        public char Character;
        public char[,] board;
        private Dictionary<string, BoardItem> BoardItems = new Dictionary<string, BoardItem>();

        public Board(int rows = 10, int collumns = 10, char character = '.'){
            (Rows, Collumns, Character) = (rows, collumns, character);
            initBoard();
            initBoardItems();
            print();
        }

        // fill the board with character, default '.'
        private void initBoard(){
            board = new char[Rows, Collumns];   
            int row = board.GetLength(0);
            int col = board.GetLength(1);      

            for (int i = 0; i < row * col; i++)
            {
                board[i / col , i % col] = Character;
            }
        }

        // just initialize the board items objects
        private void initBoardItems(){
            BoardItems.Add("food", new Food("food", '@'));
        }

        private void putItemsInBoard(){
            // check for a whitespace and put in the item
            void checkWhiteSpaceAndPutIn(BoardItem item){
                while(true){
                    var (iPos, jPos) = Utils.Utils.randomBoardPosition(Rows, Collumns);
                    if(board[iPos, jPos] == Character ){
                        item.setVisible();
                        board[iPos, jPos] = item.Character;
                        break;
                    }
                }
            }

            foreach (var item in BoardItems)
            {
                if(!item.Value.IsVisible){
                    checkWhiteSpaceAndPutIn(item.Value);
                }
                // create new item
                else if(item.Value.IsUsed && item.Value.IsVisible){
                    // TODO: add board items with a Items class dictonary or something like that
                    BoardItem newItem = new BoardItem("food", '@', 3);
                    BoardItems.Add(item.Key, newItem);
                    checkWhiteSpaceAndPutIn(newItem);
                }
            }
        
        }

        private void print(){
            Clear();

            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            string boardStr = "";
            string auxStr;

            for (int i = 0; i < rows; i++)
            {
                auxStr = "";
                for (int j = 0; j < cols; j++)
                {
                    auxStr += board[i, j];
                }
                boardStr += auxStr + "\n";
            }

            WriteLine(boardStr);
        }

        // update board matrix
        public void update(Snake snake, bool isFirstPrint = false){
            List<SnakePart> snakeBodyParts = snake.SnakeBodyParts;
            // put snake in board
            for (int i = 0; i < snakeBodyParts.Count; i++)
            {
                var (iPos, jPos) = snakeBodyParts[i];
                char snakeCharacter = snakeBodyParts[i].character;

                board[iPos, jPos] = snakeCharacter; 
            }

            // delete old snake position
            if(!isFirstPrint){
                var (iPos, jPos) = snake.Tail;
                board[iPos, jPos] = this.Character;           
            }

            putItemsInBoard();
            print();
        }


    }
}