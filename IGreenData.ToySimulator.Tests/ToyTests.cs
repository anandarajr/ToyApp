

using IGreenData.ToyApplication;

namespace IGreenData.ToySimulator.Tests
{
    [TestClass]
    public class ToyTests
    {
        IToySurfacer toySurface = null;
        IToy robot = null;
        IToySimulator toyPlayer = null;

        [TestInitialize]
        public void Initialise()
        {
            toySurface = new ToySurface(5, 5);
            robot = new Toy(toySurface);
            toyPlayer = new ToySimulator(robot);
        }

        [TestMethod]
        public void VerifytheMovementNorth()
        {
            toyPlayer.TriggerCommand("PLACE 0,0,NORTH");
            Assert.AreEqual(robot.Direction, MovementDirection.NORTH);
        }

        [TestMethod]
        public void VerifyMovementSOUTH()
        {
            toyPlayer.TriggerCommand("PLACE 0,0,SOUTH");
            Assert.AreEqual(robot.Direction, MovementDirection.SOUTH);
        }

        [TestMethod]
        public void VerifyMovementEAST()
        {
            toyPlayer.TriggerCommand("PLACE 0,0,EAST");
            Assert.AreEqual(robot.Direction, MovementDirection.EAST);
        }

        [TestMethod]
        public void VerifyMovementWEST()
        {
            toyPlayer.TriggerCommand("PLACE 0,0,WEST");
            Assert.AreEqual(robot.Direction, MovementDirection.WEST);
        }

        [TestMethod]
        public void VerifyCommandREPORT()
        {
            toyPlayer.TriggerCommand("PLACE 3,4,WEST");
            toyPlayer.TriggerCommand("REPORT");
            Assert.AreEqual(robot.Direction, MovementDirection.WEST);
            Assert.AreEqual(robot.XPosition, 3);
            Assert.AreEqual(robot.YPosition, 4);
        }

        [TestMethod]
        public void VerifyCommandLEFT()
        {
            toyPlayer.TriggerCommand("PLACE 3,4,NORTH");
            toyPlayer.TriggerCommand("LEFT");            
            Assert.AreEqual(robot.Direction, MovementDirection.WEST);

            toyPlayer.TriggerCommand("PLACE 3,4,WEST");
            toyPlayer.TriggerCommand("LEFT");
            Assert.AreEqual(robot.Direction, MovementDirection.SOUTH);

            toyPlayer.TriggerCommand("PLACE 3,4,SOUTH");
            toyPlayer.TriggerCommand("LEFT");
            Assert.AreEqual(robot.Direction, MovementDirection.EAST);

            toyPlayer.TriggerCommand("PLACE 3,4,EAST");
            toyPlayer.TriggerCommand("LEFT");
            Assert.AreEqual(robot.Direction, MovementDirection.NORTH);
        }

        [TestMethod]
        public void VerifyCommandRIGHT()
        {
            toyPlayer.TriggerCommand("PLACE 3,4,NORTH");
            toyPlayer.TriggerCommand("RIGHT");
            Assert.AreEqual(robot.Direction, MovementDirection.EAST);

            toyPlayer.TriggerCommand("PLACE 3,4,EAST");
            toyPlayer.TriggerCommand("RIGHT");
            Assert.AreEqual(robot.Direction, MovementDirection.SOUTH);

            toyPlayer.TriggerCommand("PLACE 3,4,SOUTH");
            toyPlayer.TriggerCommand("RIGHT");
            Assert.AreEqual(robot.Direction, MovementDirection.WEST);

            toyPlayer.TriggerCommand("PLACE 3,4,WEST");
            toyPlayer.TriggerCommand("RIGHT");
            Assert.AreEqual(robot.Direction, MovementDirection.NORTH);
        }

    }
}
