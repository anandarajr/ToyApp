using IGreenData.ToyApplication;

namespace IGreenData.ToyApplication
{
    using IGreenData.ToySimulator;
    using System;
    
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

   

    
}