namespace GeometriskaFigurer
{
    public static class NextFloatHelpers
    {
        public static float Next(Random random)
        {
            double mantissa = (random.NextSingle() * 2.0) - 1.0;
            // choose -149 instead of -126 to also generate subnormal floats (*)
            double exponent = Math.Pow(2.0, random.Next(-100, 100));
            return (float)(mantissa * exponent);
        }

        public static float NextFloat(float min = 0.0f, float max = 100.0f)

        {

            Random random = new Random();

            float val = random.NextSingle() * (max - min) + min ;

            return MathF.Round(val,2);

        }
    }
}