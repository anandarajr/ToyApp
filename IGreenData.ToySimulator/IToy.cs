
namespace IGreenData.ToySimulator
{
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
}
