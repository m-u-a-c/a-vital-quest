namespace Assets.Items
{
    public abstract class BaseClassItem
    {
        public string ItemName { get; set; }
        public int animation = 4;
        //NOTE: Effect is called once per frame
        abstract public void Effect();
        abstract public void Stats();
        abstract public void RevertStats();
    }
}
