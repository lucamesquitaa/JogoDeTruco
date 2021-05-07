using System;
using System.Collections.Generic;
using System.Text;

namespace Truco_v1
{
    class Carta
    {
		private static String numCarta;
		private static String naipeCarta;


		public String getCarta()
		{
			numCarta = numero();
			naipeCarta = naipe();

			String carta = numCarta + naipeCarta;

			return carta;
		}

		public static String numero()
		{
			Random random = new Random();
			int pos = 0;
			do
			{
				pos = random.Next(12);

			} while ((pos == 0 || pos == 1));
			switch (pos)//pega o numero aleatório e distribui ele para A, Q, J, K ou o número da posição que caiu.
			{
				case 8:
					numCarta = "A";
					return numCarta;
				case 9:
					numCarta = "Q";
					return numCarta;
				case 10:
					numCarta = "J";
					return numCarta;
				case 11:
					numCarta = "K";
					return numCarta;
				default:
					numCarta = "" + pos;
					return numCarta;
			}

		}
		public static String naipe()
		{
			Random random = new Random();
			int valorAleatorio = random.Next(4);
			switch (valorAleatorio)
			{
				case 0:
					naipeCarta = "C";
					return naipeCarta;
				case 1:
					naipeCarta = "O";
					return naipeCarta;
				case 2:
					naipeCarta = "E";
					return naipeCarta;
				case 3:
					naipeCarta = "P";
					return naipeCarta;
				default:
					naipeCarta = "";
					return naipeCarta;
			}
		}


	}

}
