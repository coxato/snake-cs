namespace snake_cs.GameObjects
{
    public class SnakePart
    {
        public int iPos;
        public int jPos;
        public char character;

        public SnakePart(int iPos, int jPos, char character = '#'){
            this.iPos = iPos;
            this.jPos = jPos;
            this.character = character;
        }

        public void updatePosition(int newIPos, int newJPos){
            iPos = newIPos;
            jPos = newJPos;
        }

        // Object deconstruct properties like javascript
        public void Deconstruct(out int iPos, out int jPos){
            iPos = this.iPos;
            jPos = this.jPos;
        }

    }
}