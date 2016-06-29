using System.Windows.Media;

namespace DDesignTest_Folomeev
{
    /// <summary>
    /// Класс модели цвета
    /// </summary>
    public class ColorViewModel
    {
        public string Name { get; set; }
        public SolidColorBrush ColorBrush { get; set; }

        public ColorViewModel(string name, Color color)
        {
            Name = name;
            ColorBrush = new SolidColorBrush(color);
        }
    }
}
