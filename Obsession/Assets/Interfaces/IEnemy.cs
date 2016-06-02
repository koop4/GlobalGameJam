namespace Assets.Interfaces
{
    public interface IEnemy
    {
        int Idx { get; set; }
        bool IsMale { get; set; }
        bool IsAlive { get; set; }
        void Walk();
    }
}
