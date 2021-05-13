
    [System.Serializable]
    public class HighScoreDataModel
    {
        public int sno;
        public string name;
        public int score;

        public HighScoreDataModel(int sno, string name, int score)
        {
            this.sno = sno;
            this.name = name;
            this.score = score;
        }
    };

