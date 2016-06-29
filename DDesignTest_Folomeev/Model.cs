using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DDesignTest_Folomeev
{
    /// <summary>
    /// Класс модели потока
    /// </summary>
    class Model
    {

        /// <summary>
        /// Метод запускает поток через задачу в асинхронном режиме
        /// </summary>
        /// <returns></returns>
        public void deepWait()
        {

            DeepThreadClass DTC = new DeepThreadClass(); // Инициализируем класс, где выполняется спящий поток

            DTC.StartDeepThreadWork(); // Создаём задачу, которая запускает поток в "глубине модели"                        
  
        }
    }
}
