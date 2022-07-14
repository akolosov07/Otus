namespace hw_17_delegates_events
{
    public static class Extensions
    {
        /// <summary>
        /// 1. Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции. Функция должна
        /// принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения. 
        /// public static T GetMax(this IEnumerable e, Func<T, float> getParameter) where T : class;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="getParameter"></param>
        /// <returns></returns>
        public static T GetMax<T>(this IEnumerable<T> list, Func<T, float> getParameter) where T : class
        {
            T result = list.FirstOrDefault();
            if (result != null)
            {
                float bestMax = getParameter(result);
                foreach (var item in list.Skip(1))
                {
                    float floatNumber = getParameter(item);
                    if (floatNumber.CompareTo(bestMax) > 0)
                    {
                        bestMax = floatNumber;
                        result = item;
                    }
                }
            }
            return result;
        }
    }
}
