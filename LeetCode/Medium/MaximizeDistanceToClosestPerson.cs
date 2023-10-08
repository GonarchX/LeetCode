namespace LeetCode.Medium;

// 849. Maximize Distance to Closest Person
// https://leetcode.com/problems/maximize-distance-to-closest-person/
public class MaximizeDistanceToClosestPerson
{
    public class Solution
    {
        // Суть задачи примерно в следующем:
        // Нужно найти наибольший интервал в исходном массиве, чтобы слева и справа этого интервала стояли "1",
        // найдя такой интервал, мы просто делим его длину на 2 и получаем максимальное расстояние до ближайшей "1"

        // Сам алгоритм:
        // Мы рассматриваем массив мест не целиком, а интервалами, окруженными занятыми местами, например:
        // Дан массив [1 0 0 1 0 1]
        // Мы рассматриваем только два интервала [1 0 0 1] и [1 0 1], с тем условием, 
        // что справа и слева таких массивов будут стоять "1", а между ними "0".
        // При этом, возможны ситуации, когда в таком массиве самое левое или правое место свободно, например:
        // [0, 0, 1, 0, 1]
        // [1, 0, 1, 0, 0]
        // Для этих случаев, нам необходимо в конце алгоритма сравнить максимальное расстояние между занятыми местами
        // с расстоянием от начала массива до первого занятого места и от последнего занятого места до конца массива 

        public int MaxDistToClosest(int[] seats)
        {
            int maxDist = 1;
            int lastOccSeat = -1; // Последнее занятое место
            int firstPersonSeat = -1; // Первое занятое место

            for (int curSeat = 0; curSeat < seats.Length; ++curSeat)
            {
                // Если место занято, то начинаем рассматривать интервал
                if (seats[curSeat] == 1)
                {
                    // Первое занятое место сохраняем лишь в первый раз (логично)
                    firstPersonSeat = firstPersonSeat == -1 ? curSeat : firstPersonSeat;
                    // Максимальное расстояние до ближайшего соседа считаем как половина от расстояния между занятыми местами 
                    maxDist = Math.Max(maxDist, (curSeat - lastOccSeat) / 2);
                    // Указываем правую границу диапазона, где было занятое место как последнее занятое место в нашем диапазоне (логично)
                    lastOccSeat = curSeat;
                }
            }

            // Сравниваем максимальное расстояние до ближайшего соседа с расстоянием от правого края ряда до самого правого занятого места   
            maxDist = Math.Max(maxDist, seats.Length - lastOccSeat - 1);
            // Полученный результат сравниваем с расстоянием от левого края до самого левого занятого места
            maxDist = Math.Max(maxDist, firstPersonSeat);
            
            return maxDist;
        }
    }
}