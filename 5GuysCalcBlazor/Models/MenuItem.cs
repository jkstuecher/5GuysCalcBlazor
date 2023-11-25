namespace _5GCalc.Models
{
    public class MenuItem
    {
        public string? ItemName { get; set; }
        public int ServingSize { get; set; }
        public int Calories { get; set; }
        public int CaloriesFromFat { get; set; }
        public int TotalFat { get; set; }
        public double SaturatedFat { get; set; }
        public int TransFat { get; set; }
        public int Cholesterol { get; set; }
        public int Sodium { get; set; }
        public double Carbs { get; set; }
        public int Fiber { get; set; }
        public double Sugar { get; set; }
        public double Protein { get; set; }
        public string? ServingSizeUnit { get; set; }
        public string? Section { get; set; }
        public int SectionOrder { get; set; }
        public int ItemOrder { get; set; }
    }
}
