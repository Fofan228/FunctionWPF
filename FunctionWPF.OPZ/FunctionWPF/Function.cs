using Function.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Point = System.Windows.Point;

namespace FunctionWPF
{
    class Function
    {
        private Canvas canvas;
        private Brush ColorOfPoint = Brushes.Pink;
        private Brush ColorOfLine = Brushes.Blue;
        private Brush ColorOfAxis = Brushes.Red;
        public string FunctionInput { get; }
        public Function(Canvas canvas, string function)
        {
            this.canvas = canvas;
            this.FunctionInput = function;
        }
        public void DrowFunction(double step)
        {
            Point? startPoint = null;
            for (double x = -canvas.ActualWidth/2; x < canvas.ActualWidth / 2; x += step)
            {
                var calculate = new Callculator();
                var rpn = new RPN();
                double y = calculate.CallculateRPN(rpn.ConvertToRPN(this.FunctionInput), x);
                if (Math.Abs(y*step) < canvas.ActualHeight / 2)
                {
                    var ellips = new Ellipse();
                    ellips.Width = step;
                    ellips.Height = step;
                    ellips.Fill = ColorOfPoint;
                    Canvas.SetLeft(ellips, x*step + canvas.ActualWidth / 2);
                    Canvas.SetTop(ellips, canvas.ActualHeight / 2 - y*step);
                    canvas.Children.Insert(0, ellips);
                    if (startPoint != null)
                    {
                        DrawLine(startPoint.Value, new Point(x*step + canvas.ActualWidth / 2, canvas.ActualHeight / 2 - y*step), ColorOfLine);
                    }
                    startPoint = new Point(x*step + canvas.ActualWidth / 2, canvas.ActualHeight / 2 - y*step);
                }
                else
                {
                    startPoint = null;
                }
            }
        }
        public void DrawAxes()
        {
            PointCollection OX = new PointCollection()
            {
                new Point(0, (int)(canvas.ActualHeight / 2)),
                new Point(canvas.ActualWidth, (int)(canvas.ActualHeight / 2))
            };
            PointCollection OY = new PointCollection()
            {
                new Point((int)(canvas.ActualWidth / 2), 8),
                new Point((int)(canvas.ActualWidth / 2), canvas.ActualHeight)
            };
            PointCollection OXArrows = new PointCollection()
            {
                new Point(canvas.ActualWidth, (int)(canvas.ActualHeight / 2)),
                new Point(canvas.ActualWidth, (int)(canvas.ActualHeight / 2)),
                new Point(canvas.ActualWidth, (int)(canvas.ActualHeight / 2))
            };
            PointCollection OYArrows = new PointCollection()
            {
                new Point((int)(canvas.ActualWidth / 2), 0),
                new Point((int)(canvas.ActualWidth / 2), 8),
                new Point((int)(canvas.ActualWidth / 2), 8)
            };

            DrawLine(OX[0], OX[1], ColorOfAxis);
            DrawArrows(OXArrows);
            DrawLine(OY[0], OY[1], ColorOfAxis);
            DrawArrows(OYArrows);
        }
        private void DrawLine(Point start, Point end, Brush color)
        {
            var line = new Line();
            if (start.X < canvas.ActualWidth && start.Y < canvas.ActualHeight)
            {
                line.X1 = start.X;
                line.X2 = end.X;
                line.Y1 = start.Y;
                line.Y2 = end.Y;
                line.StrokeThickness = 2;
                line.Stroke = color;
                canvas.Children.Insert(0, line);
            }
        }
        private void DrawArrows(PointCollection tops)
        {
            Polygon polygon = new Polygon();
            polygon.Points = tops;
            polygon.Fill = ColorOfAxis;
            canvas.Children.Insert(0, polygon);
        }
    }
}
