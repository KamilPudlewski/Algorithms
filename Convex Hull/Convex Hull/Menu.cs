using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convex_Hull
{
    public partial class Menu : Form
    {
        private List<Point> points = new List<Point>();
        private List<Point> convexPoints = new List<Point>();
        private List<List<Point>> convexPointsStepByStep = new List<List<Point>>();

        private bool enablePaint = true;
        private int pointSize = 8;
        private int step = 2;

        public Menu()
        {
            InitializeComponent();
            ClearPictureBox();
            pointsCounterTextBox.Text = "10";
        }

        private void ConvexHull_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (enablePaint)
            {
                Point point = new Point(e.X, e.Y);
                points.Add(point);
                DrawPoint(point);
                step = 2;
            }
        }

        private void ClearPictureBox()
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.White);
        }

        private void DrawPoint(Point point)
        {
            if (point != null )
            {
                Graphics g = pictureBox.CreateGraphics();
                g.FillEllipse(Brushes.Black, point.X - pointSize / 2, point.Y - pointSize / 2, pointSize, pointSize);
            }
        }

        private void DrawEdge(Point point1, Point point2)
        {
            if (point1 != null && point2 != null)
            {
                Graphics g = pictureBox.CreateGraphics();
                g.DrawLine(Pens.Black, point1.X, point1.Y, point2.X, point2.Y);
            }
        }

        private void DrawAllPoints()
        {
            foreach (Point point in points)
            {
                DrawPoint(point);
            }
        }

        private void DrawConvexHull()
        {
            for (int i = 1; i < convexPoints.Count; i++)
            {
                Point point1 = convexPoints[i - 1];
                Point point2 = convexPoints[i];
                DrawEdge(point1, point2);
            }

            Point point3 = convexPoints[0];
            Point point4 = convexPoints[convexPoints.Count - 1];
            DrawEdge(point3, point4);
        }

        private void DrawConvexHullStep(int step)
        {
            for (int i = 1; i < convexPointsStepByStep[step].Count; i++)
            {
                Point point1 = convexPointsStepByStep[step][i - 1];
                Point point2 = convexPointsStepByStep[step][i];
                DrawEdge(point1, point2);
            }

            if (convexPointsStepByStep.Count - 1 == step)
            {
                Point point3 = convexPointsStepByStep[step][0];
                Point point4 = convexPointsStepByStep[step][convexPointsStepByStep[step].Count - 1];
                DrawEdge(point3, point4);
            }
        }
        private void StartComputeConvexHull()
        {
            ConvexHull convexHull = new ConvexHull(points);
            convexPoints = convexHull.ComputeConvexHull();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ClearPictureBox();
            DrawAllPoints();

            if (points.Count > 0)
            {
                StartComputeConvexHull();
                DrawConvexHull();
            }
        }

        private void DrawConvexHullStepByStep(int step)
        {
            ClearPictureBox();
            DrawAllPoints();
            DrawConvexHullStep(step);
        }

        private void StartComputeConvexHullStepByStep(ref int step)
        {
            DrawConvexHullStepByStep(step);
            if (convexPointsStepByStep.Count - 1 > step)
            {
                step++;
            }
            else if (convexPointsStepByStep.Count - 1 == step)
            {
                step = 2;
            }
        }

        private void startButtonSteps_Click(object sender, EventArgs e)
        {
            if (step == 2)
            {
                ConvexHull convexHull = new ConvexHull(points);
                convexPointsStepByStep = convexHull.ComputeConvexHullStepByStep();
            }

            if (points.Count > 0)
            {
                StartComputeConvexHullStepByStep(ref step);
            }
        }

        private void randomizePointsButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            ClearPictureBox();

            Random random = new Random();
            float minimumX = 20f;
            float maximumX = 760f;
            float minimumY = 20f;
            float maximumY = 340f;

            for (int i = 0; i < Int32.Parse(pointsCounterTextBox.Text); i++)
            {
                float X = (float)random.NextDouble() * (maximumX - minimumX) + minimumX;
                float Y = (float)random.NextDouble() * (maximumY - minimumY) + minimumY;
                points.Add(new Point(X, Y));
            }
            DrawAllPoints();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            ClearPictureBox();
            step = 2;
        }

        private void pointsCounterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(pointsCounterTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers");
                pointsCounterTextBox.Text = pointsCounterTextBox.Text.Remove(pointsCounterTextBox.Text.Length - 1);
            }
        }
    }
}