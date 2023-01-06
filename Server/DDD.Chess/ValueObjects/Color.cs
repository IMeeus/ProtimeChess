﻿namespace DDD.Chess.ValueObjects
{
    public class Color
    {
        private readonly string _value;

        public static Color BLACK => new("Black");
        public static Color WHITE => new("White");

        public Color(string value)
        {
            _value = value;
        }

        public Color GetOpposite()
        {
            if (_value == "White")
                return BLACK;
            else
                return WHITE;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}