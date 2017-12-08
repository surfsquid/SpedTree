namespace SpedTree
{
    public class TreeParameters
    {
        public TreeParameters(char leaf, char stump, char bauble, int height)
        {
            Leaf = leaf;
            Stump = stump;
            Bauble = bauble;
            Height = height;
        }

        public char Leaf { get; }
        public char Stump { get; }
        public char Bauble { get; }
        public int Height { get; }
    }
}
