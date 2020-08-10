namespace snake_cs.GameObjects
{
    // ===== TODO =====
    // just pass one parameter to determinate if item is food, bomb, time, etc

    // father class
    public class BoardItem
    {
        public string Name;
        public char Character;
        public int Points;
        public bool IsUsed = false;
        public bool IsVisible = false;

        public BoardItem(string name, char character = '$', int points = 3){
            (Name, Character, Points) = (name, character, points);
        }

        public void setUse(){
            IsUsed = true;
        }

        public void setVisible(){
            IsVisible = true;
        }
    }



    // food item
    public class Food : BoardItem{
        
        public Food(string name, char character = '$', int points = 3) : base(name, character, points){}
        
    }

    
}