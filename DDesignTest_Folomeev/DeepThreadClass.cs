using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDesignTest_Folomeev
{
    class DeepThreadClass
    {
        /// <summary>
        /// Метод усыпления потока на случайное время
        /// </summary>
        public void StartDeepThreadWork()
        {
            Random rnd = new Random();

            int sleepTime = rnd.Next(3000, 10000); // Генерируем случайное время сна

            Thread.Sleep(sleepTime);

        }
    }
}
