using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class seatBuy
    {
        bool[,] selectedState = new bool[3, 5];
        int[,] ticketPrice = new int[3, 5];
        string filmName;

        public seatBuy(int filmPrice, string name)
        {

            ticketPrice[0, 0] = filmPrice / 4;
            ticketPrice[0, 4] = filmPrice / 4;
            ticketPrice[1, 0] = filmPrice / 4;
            ticketPrice[1, 4] = filmPrice / 4;
            ticketPrice[2, 0] = filmPrice / 4;
            ticketPrice[2, 4] = filmPrice / 4;

            ticketPrice[0, 1] = filmPrice;
            ticketPrice[0, 2] = filmPrice;
            ticketPrice[0, 3] = filmPrice;
            ticketPrice[2, 1] = filmPrice;
            ticketPrice[2, 2] = filmPrice;
            ticketPrice[2, 3] = filmPrice;

            ticketPrice[1, 1] = filmPrice * 2;
            ticketPrice[1, 2] = filmPrice * 2;
            ticketPrice[1, 3] = filmPrice * 2;

            filmName = name;
        }
        public bool get_state(int x, int y)
        {
            return selectedState[x, y];
        }

        public int get_price(int x, int y)
        {
            return ticketPrice[x, y];
        }

        public void set_state(int x, int y, bool state)
        {
            selectedState[x, y] = state;
        }
    }
}
