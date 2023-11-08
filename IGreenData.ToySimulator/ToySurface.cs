namespace IGreenData.ToySimulator
{
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
}
