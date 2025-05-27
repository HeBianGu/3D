//#define IRB6700

using System.Windows.Media.Media3D;


/**
 * Author: Gabriele Marini (Gabryxx7)
 * This class load the 3d models of all the parts of the robotic arms and add them to the viewport
 * It also defines the relations among the joints of the robotic arms in order to reflect the movement of the robot in the real world
 * **/
namespace RobotArmHelix1
{
    internal class Joint
    {
        public Model3D model = null;
        public double angle = 0;
        public double angleMin = -180;
        public double angleMax = 180;
        public int rotPointX = 0;
        public int rotPointY = 0;
        public int rotPointZ = 0;
        public int rotAxisX = 0;
        public int rotAxisY = 0;
        public int rotAxisZ = 0;

        public Joint(Model3D pModel)
        {
            model = pModel;
        }

    }

}
