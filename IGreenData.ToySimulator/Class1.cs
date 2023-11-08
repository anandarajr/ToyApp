using IGreenData.ToyApplication;

namespace IGreenData.ToyApplication
{
    using System;
    
    public interface IToy
    {

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        MovementDirection Direction { get; set; }

        /// <summary>
        /// Set the Toy Toy
        /// </summary>
        /// <param name="xPosition">Position of X Coordinate</param>
        /// <param name="yPosition">Position of Y Coordinate</param>
        /// <param name="movementDirection">Movement direction</param>
        void Set(int xPosition, int yPosition, MovementDirection movementDirection);

        /// <summary>
        /// Allow the Toy to move
        /// </summary>
        void Move();

        /// <summary>
        /// Allow the Toy to move to Left
        /// </summary>
        void Left();

        /// <summary>
        /// Allow the Toy to move to right
        /// </summary>
        void Right();

        /// <summary>
        /// Print the Current Position of the Toy
        /// </summary>
        void GetCurrentPosition();
    }

    public interface IToySurfacer
    {
        bool IsPositionValid(int x, int y);
    }

    /// <summary>
    /// Enum of Movement Direction of Toy
    /// </summary>
    public enum MovementDirection
    {
        NONE,
        NORTH,
        SOUTH,
        WEST,
        EAST
    }

    /// <summary>
    /// Input Command Action
    /// </summary>
    public enum InputCommandAction
    {
        PLACE,
        MOVE,
        LEFT,
        RIGHT,
        REPORT
    }
    /// <summary>
    /// Toy
    /// </summary>
    public class Toy : IToy
    {
        #region Private variables
       
        private IToySurfacer _toySurfacer;
        #endregion

        #region Public variables
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public MovementDirection Direction { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize Position of the Toy
        /// </summary>
        /// <param name="toySurfacer"></param>
        public Toy(IToySurfacer toySurfacer)
        {
            this._toySurfacer = toySurfacer;
            this.XPosition = -1;
            this.YPosition = -1;
            this.Direction = MovementDirection.NONE;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Verify the toy position and reset to the new position with direction
        /// </summary>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        /// <param name="direction"></param>
        public void Set(int xPosition, int yPosition, MovementDirection direction)
        {
            if (_toySurfacer.IsPositionValid(xPosition, yPosition))
            {
                this.XPosition = xPosition;
                this.YPosition = yPosition;
                this.Direction = direction;
            }
        }

        /// <summary>
        /// Implementation of Moving the toy
        /// </summary>
        public void Move()
        {
            if (_toySurfacer.IsPositionValid(XPosition, YPosition))
            {
                int currentXPosition = XPosition;
                int currentYPosition = YPosition;

                switch (Direction)
                {
                    case MovementDirection.NORTH:
                        currentYPosition++;
                        break;
                    case MovementDirection.SOUTH:
                        currentYPosition--;
                        break;
                    case MovementDirection.EAST:
                        currentXPosition++;
                        break;
                    case MovementDirection.WEST:
                        currentXPosition--;
                        break;
                }

                //Verify the validity of the position and then reset x and y
                if (_toySurfacer.IsPositionValid(currentXPosition, currentYPosition))
                {
                    XPosition = currentXPosition;
                    YPosition = currentYPosition;
                }
            }
        }

        /// <summary>
        /// Implementation of moving the toy to Left
        /// </summary>
        public void Left()
        {
            switch (Direction)
            {
                case MovementDirection.NORTH:
                    Direction = MovementDirection.WEST;
                    break;
                case MovementDirection.WEST:
                    Direction = MovementDirection.SOUTH;
                    break;
                case MovementDirection.SOUTH:
                    Direction = MovementDirection.EAST;
                    break;
                case MovementDirection.EAST:
                    Direction = MovementDirection.NORTH;
                    break;
            }
        }

        /// <summary>
        /// Implementation of moving the toy to Right
        /// </summary>
        public void Right()
        {
            switch (Direction)
            {
                case MovementDirection.NORTH:
                    Direction = MovementDirection.EAST;
                    break;
                case MovementDirection.EAST:
                    Direction = MovementDirection.SOUTH;
                    break;
                case MovementDirection.SOUTH:
                    Direction = MovementDirection.WEST;
                    break;
                case MovementDirection.WEST:
                    Direction = MovementDirection.NORTH;
                    break;
            }
        }

        /// <summary>
        /// Implementation of getting the current position
        /// </summary>
        public void GetCurrentPosition()
        {
            Console.WriteLine($"Toy is at ({XPosition}, {YPosition}) facing {Direction}");
        }
        #endregion
    }

    /// <summary>
    /// Surace on which Toy will move
    /// </summary>
    public class ToySurface : IToySurfacer
    {
        #region Private variables
        private int _maxWidth;
        private int _maxHeight;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize the Width and Height of the table
        /// </summary>
        /// <param name="maxWidth">Width of Table Topper</param>
        /// <param name="maxHeight">Height of Table Topper</param>
        public ToySurface(int maxWidth, int maxHeight)
        {
            this._maxWidth = maxWidth;
            this._maxHeight = maxHeight;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Verify whether current position of toy is valid or not
        /// </summary>
        /// <param name="xPosition">X Position</param>
        /// <param name="yPosition">Y Position</param>
        /// <returns>boolean flag</returns>
        public bool IsPositionValid(int xPosition, int yPosition)
        {
            return xPosition >= 0 && xPosition < _maxWidth && yPosition >= 0 && yPosition < _maxHeight;
        }
        #endregion
    }

    public interface IToySimulator
    {
        void TriggerCommand(string inputCommands);
    }

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