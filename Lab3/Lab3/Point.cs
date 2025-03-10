﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab3
{
    public class Point
    {
        private double x, y;
        #region Undo_functionality
        //TODO
        // tinem un istoric al valorilor pe care le-a avut punctul
        Stack<Point> history = new Stack<Point>();
        private double start_x;
        private double start_y;
        public void StepBack()
        {
            history.Pop();
            Point point = history.Pop();
            x = point.x;
            y = point.y;
        }

        public void Reset()
        {
            this.x = this.start_x;
            this.y = this.start_y;
            history.Clear();
        }
        #endregion

        #region c-tors
        public Point(): this(0.0, 0.0)
        {

        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.start_x = x;
            this.start_y = y;
        }

        /// <summary>
        /// initializeaza un Point pe baza unui string de forma "(3.0;4.0)"
        /// </summary>
        /// <param name="str"></param>
        public Point(string str)
        {
            // TODO 
            // creati un Regex care verifica daca stringul are forma potrivita
            str = str.Trim();
            str = CheckAndProcess(str);
            (x, y) = ConvertMyMatchToNumbers(str);
            start_x = x;
            start_y = y;
        }
        #endregion



        #region Try to solve Regex TODO
        private static string CheckAndProcess(string str)
        {
            string pattern = @"\(\d+(\.\d+)?\;\s*\d+(\.\d+)?\)";
            Match result = Regex.Match(str, pattern);
            string output = null;
            if (result.Success)
            {
                string input = result.Value;
                
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != '(' && input[i] != ')')
                    {
                        output += input[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
            return output;
        }

        private static (double, double) ConvertMyMatchToNumbers(string output)
        {
            string[] split = output.Split(';');
            double x = double.Parse(split[0]);
            double y = double.Parse(split[1]);
            return (x, y);
        }
        #endregion

        public override string ToString()
        {
            return $"({x}; {y})";
        }

        public void MoveBy(double dx, double dy)
        {
            x += dx;
            y += dy;
            history.Push(new Point(x, y));
        }

        public double DistanceToOrigin()
        {
            return DistanceTo(new Point());
        }
        public double DistanceTo(Point p2)
        {
            double x1, y1, x2, y2;

            x1 = x;
            y1 = y;

            x2 = p2.x;
            y2 = p2.y;


            return Math.Sqrt(Math.Pow(x1 - x2, 2.0) +  Math.Pow(y1 - y2, 2.0));
        }
    }
}