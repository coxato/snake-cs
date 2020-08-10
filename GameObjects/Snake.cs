using System.Collections.Generic;
using System.Linq;


namespace snake_cs.GameObjects
{
    public class Snake
    {
        public List<SnakePart> SnakeBodyParts = new List<SnakePart>();
        public SnakePart Tail; 
    

        public Snake(int initIPos = 0, int initJPos = 0){
            // when it's created, head and tail of snake are the same 
            Tail = new SnakePart(initIPos, initJPos);
            // create head
            createHead(initIPos, initJPos);
        }


        private void createHead(int i, int j){
            if(!SnakeBodyParts.Any()){
                SnakeBodyParts.Add( new SnakePart(i, j, '@') );
            }
        }


        public void addPart(){
            // positions of tail
            var (iPos, jPos) = Tail;

            SnakeBodyParts.Add( new SnakePart(iPos, jPos) );
        }


        // save the last body position to remove it in the board when the snake is updated
        private void saveTail(){
            SnakePart tail = SnakeBodyParts.Last();
            var (iPos, jPos) = tail;
            Tail.updatePosition(iPos, jPos);
        }


        // update all the bodyParts of snake
        public void update(int newIPos, int newJPos){

            saveTail();

            if(SnakeBodyParts.Count >= 2){
                // update from last to position 1
                for (int i = SnakeBodyParts.Count - 1; i > 0; i--)
                {
                    // get positions of prev body part
                    var (iPos, jPos) = SnakeBodyParts[i - 1]; 
                    SnakeBodyParts[i].updatePosition(iPos, jPos);
                }
            }

            // then, update head
            SnakeBodyParts[0].updatePosition(newIPos, newJPos);
        }
    }


}