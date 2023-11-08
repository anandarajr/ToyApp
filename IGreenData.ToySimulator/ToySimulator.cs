namespace IGreenData.ToySimulator
{
    public class ToySimulator : IToySimulator
    {
        #region Private variables
        private IToy toy;
        #endregion

        #region Constructor to initialize
        public ToySimulator(IToy toy)
        {
            this.toy = toy;
        }
        #endregion

        #region public methods
        public void TriggerCommand(string inputCommands)
        {
            string[] inputCommandParts = inputCommands.Split(' ');

            if (inputCommandParts.Length > 0)
            {
                InputCommandAction inputCommandActionResult;
                var inputCommandAction = Enum.TryParse<InputCommandAction>(inputCommandParts[0], out inputCommandActionResult);

                switch (inputCommandActionResult)
                {
                    case InputCommandAction.PLACE:
                        if (inputCommandParts.Length == 2)
                        {
                            string[] inputParameters = inputCommandParts[1].Split(',');

                            if (inputParameters.Length == 3)
                            {
                                int inputX, inputY;
                                if (int.TryParse(inputParameters[0], out inputX) && int.TryParse(inputParameters[1], out inputY))
                                {
                                    toy.Set(inputX, inputY, Enum.Parse<MovementDirection>(inputParameters[2]));
                                }
                            }
                        }
                        break;

                    case InputCommandAction.REPORT:
                        toy.GetCurrentPosition();
                        break;

                    case InputCommandAction.MOVE:
                        toy.Move();
                        break;

                    case InputCommandAction.LEFT:
                        toy.Left();
                        break;

                    case InputCommandAction.RIGHT:
                        toy.Right();
                        break;
                }
            }
        }
        #endregion
    }
}
