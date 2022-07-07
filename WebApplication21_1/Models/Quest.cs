namespace WebApplication21_1.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public int PlayersCount { get; set; }
        public Difficulty Difficulty { get; set; }
        public LevelFear LevelFear { get; set; }
    }

    public enum Difficulty
    {
        Impossible,
        Hard,
        Normal,
        Easy
    }

    public enum LevelFear
    {
        Dangerous,
        Scarary,
        Creepy,
        Funny
    }


    public enum SortState
    {
        PlayersCountAsc,    // по PlayersCountAsc по возрастанию
        PlayersCountDesc,   // по PlayersCountAsc по убывания
        DifficultyAsc,      // по DifficultyAsc по возрастанию
        DifficultyDesc,     // по DifficultyAsc по убывания
        LevelFearAsc,       // по LevelFearAsc по возрастанию
        LevelFearDesc      // по LevelFearAsc по убыванию
    }
}
