namespace Cosmos.Systems
{
    internal interface IScoreSystem
    {
        public void UpdateScore(string typeId);
        public int GetScore();
    }
}

