namespace AdventOfCode2018.Challenge7
{
    internal sealed class Worker
    {
        private const int Offset = 61;

        private char currentJob;

        private int timeLeft;

        public bool IsWorking => timeLeft > 0;

        public char? Tick()
        {
            if (IsWorking)
            {
                timeLeft--;
                if (timeLeft == 0)
                {
                    return currentJob;
                }
            }

            return null;
        }


        public void WorkOn(char step)
        {
            currentJob = step;
            timeLeft = Offset + step - 'A';
        }
    }
}
