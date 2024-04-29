namespace ReactWithASP
{
    public class MinMax
    {
        double min = 0;
        double max = Double.MaxValue;

        public double Min { 
            get { return min;  }
            set { min = value; } 
        }
        public double Max {
            get { return max; }
            set { max = value; }
        }
    }
}
