//#define IRB6700

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using System.IO;
using RobotArmHelix;

public class IRB4600
{
    private const string MODEL_PATH1 = "IRB6700-MH3_245-300_IRC5_rev02_LINK01_CAD.stl";
    private const string MODEL_PATH2 = "IRB6700-MH3_245-300_IRC5_rev00_LINK02_CAD.stl";
    private const string MODEL_PATH3 = "IRB6700-MH3_245-300_IRC5_rev02_LINK03_CAD.stl";
    private const string MODEL_PATH4 = "IRB6700-MH3_245-300_IRC5_rev01_LINK04_CAD.stl";
    private const string MODEL_PATH5 = "IRB6700-MH3_245-300_IRC5_rev01_LINK05_CAD.stl";
    private const string MODEL_PATH6 = "IRB6700-MH3_245-300_IRC5_rev01_LINK06_CAD.stl";
    private const string MODEL_PATH7 = "IRB6700-MH3_245-300_IRC5_rev02_LINK01_CABLE.stl";
    private const string MODEL_PATH8 = "IRB6700-MH3_245-300_IRC5_rev02_LINK01m_CABLE.stl";
    private const string MODEL_PATH9 = "IRB6700-MH3_245-300_IRC5_rev00_LINK02_CABLE.stl";
    private const string MODEL_PATH10 = "IRB6700-MH3_245-300_IRC5_rev00_LINK02m_CABLE.stl";
    private const string MODEL_PATH11 = "IRB6700-MH3_245-300_IRC5_rev00_LINK03a_CABLE.stl";
    private const string MODEL_PATH12 = "IRB6700-MH3_245-300_IRC5_rev00_LINK03b_CABLE.stl";
    private const string MODEL_PATH13 = "IRB6700-MH3_245-300_IRC5_rev02_LINK03m_CABLE.stl";
    private const string MODEL_PATH14 = "IRB6700-MH3_245-300_IRC5_rev01_LINK04_CABLE.stl";
    private const string MODEL_PATH15 = "IRB6700-MH3_245-300_IRC5_rev00_ROD_CAD.stl";
    private const string MODEL_PATH16 = "IRB6700-MH3_245-300_IRC5_rev00_LOGO1_CAD.stl";
    private const string MODEL_PATH17 = "IRB6700-MH3_245-300_IRC5_rev00_LOGO2_CAD.stl";
    private const string MODEL_PATH18 = "IRB6700-MH3_245-300_IRC5_rev00_LOGO3_CAD.stl";
    private const string MODEL_PATH19 = "IRB6700-MH3_245-300_IRC5_rev01_BASE_CAD.stl";
    private const string MODEL_PATH20 = "IRB6700-MH3_245-300_IRC5_rev00_CYLINDER_CAD.stl";

    List<Joint> joints = null;

    Model3DGroup RA;
    public IRB4600()
    {
        List<string> modelsNames = new List<string>();
        modelsNames.Add(MODEL_PATH1);
        modelsNames.Add(MODEL_PATH2);
        modelsNames.Add(MODEL_PATH3);
        modelsNames.Add(MODEL_PATH4);
        modelsNames.Add(MODEL_PATH5);
        modelsNames.Add(MODEL_PATH6);
        modelsNames.Add(MODEL_PATH7);
        modelsNames.Add(MODEL_PATH8);
        modelsNames.Add(MODEL_PATH9);
        modelsNames.Add(MODEL_PATH10);
        modelsNames.Add(MODEL_PATH11);//Until here for the 4600
                                      //#if IRB6700
        modelsNames.Add(MODEL_PATH12);
        modelsNames.Add(MODEL_PATH13);
        modelsNames.Add(MODEL_PATH14);
        modelsNames.Add(MODEL_PATH15);
        modelsNames.Add(MODEL_PATH16);
        modelsNames.Add(MODEL_PATH17);
        modelsNames.Add(MODEL_PATH18);
        modelsNames.Add(MODEL_PATH19);
        modelsNames.Add(MODEL_PATH20);
    }

    private Model3DGroup Initialize_Environment(List<string> modelsNames)
    {
        try
        {
            string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\3D_Models\\";

            ModelImporter import = new ModelImporter();
            joints = new List<Joint>();

            foreach (string modelName in modelsNames)
            {
                var materialGroup = new MaterialGroup();
                Color mainColor = Colors.White;
                EmissiveMaterial emissMat = new EmissiveMaterial(new SolidColorBrush(mainColor) { Opacity = 0.1 });
                DiffuseMaterial diffMat = new DiffuseMaterial(new SolidColorBrush(mainColor) { Opacity = 0.1 });
                SpecularMaterial specMat = new SpecularMaterial(new SolidColorBrush(mainColor) { Opacity = 0.1 }, 200);
                materialGroup.Children.Add(emissMat);
                materialGroup.Children.Add(diffMat);
                materialGroup.Children.Add(specMat);

                var link = import.Load(basePath + modelName);
                GeometryModel3D model = link.Children[0] as GeometryModel3D;
                model.Material = materialGroup;
                model.BackMaterial = materialGroup;
                joints.Add(new Joint(link));
            }

            RA.Children.Add(joints[0].model);
            RA.Children.Add(joints[1].model);
            RA.Children.Add(joints[2].model);
            RA.Children.Add(joints[3].model);
            RA.Children.Add(joints[4].model);
            RA.Children.Add(joints[5].model);
            RA.Children.Add(joints[6].model);
            RA.Children.Add(joints[7].model);
            RA.Children.Add(joints[8].model);
            RA.Children.Add(joints[9].model);
            RA.Children.Add(joints[10].model);
            //#if IRB6700
            RA.Children.Add(joints[11].model);
            RA.Children.Add(joints[12].model);
            RA.Children.Add(joints[13].model);
            RA.Children.Add(joints[14].model);
            RA.Children.Add(joints[15].model);
            RA.Children.Add(joints[16].model);
            RA.Children.Add(joints[17].model);
            RA.Children.Add(joints[18].model);
            RA.Children.Add(joints[19].model);
            //#endif

            //#if IRB6700
            Color cableColor = Colors.DarkSlateGray;
            changeModelColor(joints[6], cableColor);
            changeModelColor(joints[7], cableColor);
            changeModelColor(joints[8], cableColor);
            changeModelColor(joints[9], cableColor);
            changeModelColor(joints[10], cableColor);
            changeModelColor(joints[11], cableColor);
            changeModelColor(joints[12], cableColor);
            changeModelColor(joints[13], cableColor);

            changeModelColor(joints[14], Colors.Gray);

            changeModelColor(joints[15], Colors.Red);
            changeModelColor(joints[16], Colors.Red);
            changeModelColor(joints[17], Colors.Red);

            changeModelColor(joints[18], Colors.Gray);
            changeModelColor(joints[19], Colors.Gray);

            joints[0].angleMin = -180;
            joints[0].angleMax = 180;
            joints[0].rotAxisX = 0;
            joints[0].rotAxisY = 0;
            joints[0].rotAxisZ = 1;
            joints[0].rotPointX = 0;
            joints[0].rotPointY = 0;
            joints[0].rotPointZ = 0;

            joints[1].angleMin = -100;
            joints[1].angleMax = 60;
            joints[1].rotAxisX = 0;
            joints[1].rotAxisY = 1;
            joints[1].rotAxisZ = 0;
            joints[1].rotPointX = 348;
            joints[1].rotPointY = -243;
            joints[1].rotPointZ = 775;

            joints[2].angleMin = -90;
            joints[2].angleMax = 90;
            joints[2].rotAxisX = 0;
            joints[2].rotAxisY = 1;
            joints[2].rotAxisZ = 0;
            joints[2].rotPointX = 347;
            joints[2].rotPointY = -376;
            joints[2].rotPointZ = 1923;

            joints[3].angleMin = -180;
            joints[3].angleMax = 180;
            joints[3].rotAxisX = 1;
            joints[3].rotAxisY = 0;
            joints[3].rotAxisZ = 0;
            joints[3].rotPointX = 60;
            joints[3].rotPointY = 0;
            joints[3].rotPointZ = 2125;

            joints[4].angleMin = -115;
            joints[4].angleMax = 115;
            joints[4].rotAxisX = 0;
            joints[4].rotAxisY = 1;
            joints[4].rotAxisZ = 0;
            joints[4].rotPointX = 1815;
            joints[4].rotPointY = 0;
            joints[4].rotPointZ = 2125;

            joints[5].angleMin = -180;
            joints[5].angleMax = 180;
            joints[5].rotAxisX = 1;
            joints[5].rotAxisY = 0;
            joints[5].rotAxisZ = 0;
            joints[5].rotPointX = 2008;
            joints[5].rotPointY = 0;
            joints[5].rotPointZ = 2125;

            //#else
            //changeModelColor(joints[6], Colors.Red);
            //changeModelColor(joints[7], Colors.Black);
            //changeModelColor(joints[8], Colors.Black);
            //changeModelColor(joints[9], Colors.Black);
            //changeModelColor(joints[10], Colors.Gray);

            //RA.Children.Add(joints[0].model);
            //RA.Children.Add(joints[1].model);
            //RA.Children.Add(joints[2].model);
            //RA.Children.Add(joints[3].model);
            //RA.Children.Add(joints[4].model);
            //RA.Children.Add(joints[5].model);
            //RA.Children.Add(joints[6].model);
            //RA.Children.Add(joints[7].model);
            //RA.Children.Add(joints[8].model);
            //RA.Children.Add(joints[9].model);
            //RA.Children.Add(joints[10].model);

            //joints[0].angleMin = -180;
            //joints[0].angleMax = 180;
            //joints[0].rotAxisX = 0;
            //joints[0].rotAxisY = 0;
            //joints[0].rotAxisZ = 1;
            //joints[0].rotPointX = 0;
            //joints[0].rotPointY = 0;
            //joints[0].rotPointZ = 0;

            //joints[1].angleMin = -100;
            //joints[1].angleMax = 60;
            //joints[1].rotAxisX = 0;
            //joints[1].rotAxisY = 1;
            //joints[1].rotAxisZ = 0;
            //joints[1].rotPointX = 175;
            //joints[1].rotPointY = -200;
            //joints[1].rotPointZ = 500;

            //joints[2].angleMin = -90;
            //joints[2].angleMax = 90;
            //joints[2].rotAxisX = 0;
            //joints[2].rotAxisY = 1;
            //joints[2].rotAxisZ = 0;
            //joints[2].rotPointX = 190;
            //joints[2].rotPointY = -700;
            //joints[2].rotPointZ = 1595;

            //joints[3].angleMin = -180;
            //joints[3].angleMax = 180;
            //joints[3].rotAxisX = 1;
            //joints[3].rotAxisY = 0;
            //joints[3].rotAxisZ = 0;
            //joints[3].rotPointX = 400;
            //joints[3].rotPointY = 0;
            //joints[3].rotPointZ = 1765;

            //joints[4].angleMin = -115;
            //joints[4].angleMax = 115;
            //joints[4].rotAxisX = 0;
            //joints[4].rotAxisY = 1;
            //joints[4].rotAxisZ = 0;
            //joints[4].rotPointX = 1405;
            //joints[4].rotPointY = 50;
            //joints[4].rotPointZ = 1765;

            //joints[5].angleMin = -180;
            //joints[5].angleMax = 180;
            //joints[5].rotAxisX = 1;
            //joints[5].rotAxisY = 0;
            //joints[5].rotAxisZ = 0;
            //joints[5].rotPointX = 1405;
            //joints[5].rotPointY = 0;
            //joints[5].rotPointZ = 1765;
            //#endif
        }
        catch (Exception e)
        {
            MessageBox.Show("Exception Error:" + e.StackTrace);
        }
        return RA;
    }

    private Color changeModelColor(Joint pJoint, Color newColor)
    {
        Model3DGroup models = ((Model3DGroup)pJoint.model);
        return changeModelColor(models.Children[0] as GeometryModel3D, newColor);
    }
    Color oldColor = Colors.White;
    private Color changeModelColor(GeometryModel3D pModel, Color newColor)
    {
        if (pModel == null)
            return oldColor;

        Color previousColor = Colors.Black;

        MaterialGroup mg = (MaterialGroup)pModel.Material;
        if (mg.Children.Count > 0)
        {
            try
            {
                previousColor = ((EmissiveMaterial)mg.Children[0]).Color;
                ((EmissiveMaterial)mg.Children[0]).Color = newColor;
                ((DiffuseMaterial)mg.Children[1]).Color = newColor;

            }
            catch (Exception exc)
            {
                previousColor = oldColor;
            }
        }

        return previousColor;
    }



    public double Angle1
    {
        get { return joints[0].angle; }
        set
        {
            joints[0].angle = value;
            execute_fk();
        }
    }
    public double Angle2
    {
        get { return joints[1].angle; }
        set
        {
            joints[1].angle = value;
            execute_fk();
        }
    }
    public double Angle3
    {
        get { return joints[20].angle; }
        set
        {
            joints[2].angle = value;
            execute_fk();
        }
    }
    public double Angle4
    {
        get { return joints[3].angle; }
        set
        {
            joints[3].angle = value;
            execute_fk();
        }
    }
    public double Angle5
    {
        get { return joints[4].angle; }
        set
        {
            joints[4].angle = value;
            execute_fk();
        }
    }
    public double Angle6
    {
        get { return joints[5].angle; }
        set
        {
            joints[5].angle = value;
            execute_fk();
        }
    }

    //private void ValueChanged(double angle1,double angle2,double angle3,double angle4,double angle5,double angle6)
    //{
    //    joints[0].angle = angle1;
    //    joints[1].angle = angle2;
    //    joints[2].angle = joint3.Value;
    //    joints[3].angle = joint4.Value;
    //    joints[4].angle = joint5.Value;
    //    joints[5].angle = joint6.Value;
    //    execute_fk();
    //}

    private void execute_fk()
    {
        /** Debug sphere, it takes the x,y,z of the textBoxes and update its position
         * This is useful when using x,y,z in the "new Point3D(x,y,z)* when defining a new RotateTransform3D() to check where the joints is actually  rotating */
        double[] angles = { joints[0].angle, joints[1].angle, joints[2].angle, joints[3].angle, joints[4].angle, joints[5].angle };
        ForwardKinematics(angles);
        //updateSpherePosition();
    }

    public Vector3D ForwardKinematics(double[] angles)
    {
        //The base only has rotation and is always at the origin, so the only transform in the transformGroup is the rotation R
        Transform3DGroup F1 = new Transform3DGroup();
        RotateTransform3D R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[0].rotAxisX, joints[0].rotAxisY, joints[0].rotAxisZ), angles[0]), new Point3D(joints[0].rotPointX, joints[0].rotPointY, joints[0].rotPointZ));
        F1.Children.Add(R);

        //This moves the first joint attached to the base, it may translate and rotate. Since the joint are already in the right position (the .stl model also store the joints position
        //in the virtual world when they were first created, so if you load all the .stl models of the joint they will be automatically positioned in the right locations)
        //so in all of these cases the first translation is always 0, I just left it for future purposes if something need to be moved
        //After that, the joint needs to rotate of a certain amount (given by the value in the slider), and the rotation must be executed on a specific point
        //After some testing it looks like the point 175, -200, 500 is the sweet spot to achieve the rotation intended for the joint
        //finally we also need to apply the transformation applied to the base 
        var F2 = new Transform3DGroup();
        var T = new TranslateTransform3D(0, 0, 0);
        R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[1].rotAxisX, joints[1].rotAxisY, joints[1].rotAxisZ), angles[1]), new Point3D(joints[1].rotPointX, joints[1].rotPointY, joints[1].rotPointZ));
        F2.Children.Add(T);
        F2.Children.Add(R);
        F2.Children.Add(F1);

        //The second joint is attached to the first one. As before I found the sweet spot after testing, and looks like is rotating just fine. No pre-translation as before
        //and again the previous transformation needs to be applied
        var F3 = new Transform3DGroup();
        T = new TranslateTransform3D(0, 0, 0);
        R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[2].rotAxisX, joints[2].rotAxisY, joints[2].rotAxisZ), angles[2]), new Point3D(joints[2].rotPointX, joints[2].rotPointY, joints[2].rotPointZ));
        F3.Children.Add(T);
        F3.Children.Add(R);
        F3.Children.Add(F2);

        //as before
        var F4 = new Transform3DGroup();
        T = new TranslateTransform3D(0, 0, 0); //1500, 650, 1650
        R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[3].rotAxisX, joints[3].rotAxisY, joints[3].rotAxisZ), angles[3]), new Point3D(joints[3].rotPointX, joints[3].rotPointY, joints[3].rotPointZ));
        F4.Children.Add(T);
        F4.Children.Add(R);
        F4.Children.Add(F3);

        //as before
        var F5 = new Transform3DGroup();
        T = new TranslateTransform3D(0, 0, 0);
        R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[4].rotAxisX, joints[4].rotAxisY, joints[4].rotAxisZ), angles[4]), new Point3D(joints[4].rotPointX, joints[4].rotPointY, joints[4].rotPointZ));
        F5.Children.Add(T);
        F5.Children.Add(R);
        F5.Children.Add(F4);

        //NB: I was having a nightmare trying to understand why it was always rotating in a weird way... SO I realized that the order in which
        //you add the Children is actually VERY IMPORTANT in fact before I was applyting F and then T and R, but the previous transformation
        //Should always be applied as last (FORWARD Kinematics)
        var F6 = new Transform3DGroup();
        T = new TranslateTransform3D(0, 0, 0);
        R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[5].rotAxisX, joints[5].rotAxisY, joints[5].rotAxisZ), angles[5]), new Point3D(joints[5].rotPointX, joints[5].rotPointY, joints[5].rotPointZ));
        F6.Children.Add(T);
        F6.Children.Add(R);
        F6.Children.Add(F5);


        joints[0].model.Transform = F1; //First joint
        joints[1].model.Transform = F2; //Second joint (the "biceps")
        joints[2].model.Transform = F3; //third joint (the "knee" or "elbow")
        joints[3].model.Transform = F4; //the "forearm"
        joints[4].model.Transform = F5; //the tool plate
        joints[5].model.Transform = F6; //the tool


        //  ToDo：以最后一个位置作为目标位置，改为中心位置最好

        //Tx.Content = joints[5].model.Bounds.Location.X;
        //Ty.Content = joints[5].model.Bounds.Location.Y;
        //Tz.Content = joints[5].model.Bounds.Location.Z;
        //Tx_Copy.Content = geom.Bounds.Location.X;
        //Ty_Copy.Content = geom.Bounds.Location.Y;
        //Tz_Copy.Content = geom.Bounds.Location.Z;

        //#if IRB6700
        joints[6].model.Transform = F1;
        joints[7].model.Transform = F1;
        joints[19].model.Transform = F1;
        joints[14].model.Transform = F1;

        joints[8].model.Transform = F2;
        joints[9].model.Transform = F2;

        joints[10].model.Transform = F3;
        joints[11].model.Transform = F3;
        joints[12].model.Transform = F3;
        joints[16].model.Transform = F3;

        joints[13].model.Transform = F4;
        joints[17].model.Transform = F4;
        //#else
        //            joints[7].model.Transform = F1; //Cables

        //            joints[8].model.Transform = F2; //Cables

        //            joints[6].model.Transform = F3; //The ABB writing
        //            joints[9].model.Transform = F3; //Cables
        //#endif

        return new Vector3D(joints[5].model.Bounds.Location.X, joints[5].model.Bounds.Location.Y, joints[5].model.Bounds.Location.Z);
    }


    //private void updateSpherePosition()
    //{
    //    int sel = ((int)jointSelector.Value) - 1;
    //    if (sel < 0)
    //        return;

    //    Transform3DGroup F = new Transform3DGroup();
    //    F.Children.Add(new TranslateTransform3D(joints[sel].rotPointX, joints[sel].rotPointY, joints[sel].rotPointZ));
    //    F.Children.Add(joints[sel].model.Transform);
    //    geom.Transform = F;
    //}

}
