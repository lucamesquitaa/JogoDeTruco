using System;
using System.Collections.Generic;
using System.Text;

namespace Truco_v1
{
    class Controle
    {
		public static Carta card = new Carta();
		public static Partida pontos = new Partida();

		public static String[] cartaJogador = new String[3];
		public static String[] cartaComputador = new String[3];

		public static String cartaJogada;

		public void Baralho()
		{
			bool repetida = false;
			//confere se tem alguma carta repetida e retorna um boolean
			//o while vai embaralhar as cartas de novo ate que nao exista carta repetida
			do
			{
				for (int i = 0; i < 3; i++)
				{
					cartaJogador[i] = card.getCarta();
					cartaComputador[i] = card.getCarta();
				}
				repetida = temRepetida(cartaJogador, cartaComputador);
			} while (repetida);
		}

		public int Jogar(int num)
		{
			int peso;
			if (num == 1)
			{
				String carta = cartaJogador[0];
				peso = AtribuiValor(carta);
				Console.WriteLine("carta escolhida: " + carta);
				return peso;
			}
			else if (num == 2)
			{
				String carta = cartaJogador[1];
				peso = AtribuiValor(carta);
				Console.WriteLine("carta escolhida: " + carta);
				return peso;
			}
			else
			{
				String carta = cartaJogador[2];
				peso = AtribuiValor(carta);
				Console.WriteLine("carta escolhida: " + carta);
				return peso;
			}
		}
		public int ComputadorJoga(int[] computadorjaJogouEssa)
		{
			int peso = 0;
			bool sair = false;
			do
			{
				Random random = new Random();
				int valorAleatorio = random.Next(3);
				if (valorAleatorio == 0 && computadorjaJogouEssa[0] == 0)
				{
					String carta = cartaComputador[0];
					peso = AtribuiValor(carta);
					computadorjaJogouEssa[0] = 1;
					Console.WriteLine("carta computador: " + carta + "\n");
					sair = true;
				}
				else if (valorAleatorio == 1 && computadorjaJogouEssa[1] == 0)
				{
					String carta = cartaComputador[1];
					peso = AtribuiValor(carta);
					computadorjaJogouEssa[1] = 1;
					Console.WriteLine("carta computador: " + carta + "\n");
					sair = true;
				}
				else if (valorAleatorio == 2 && computadorjaJogouEssa[2] == 0)
				{
					String carta = cartaComputador[2];
					peso = AtribuiValor(carta);
					computadorjaJogouEssa[2] = 1;
					Console.WriteLine("carta computador: " + carta + "\n");
					sair = true;
				}
				
			} while (!sair);

			return peso;
		}

		public static int AtribuiValor(String card)
		{
			int retorno = 0;
			String[] vetCartas = {"4P","7C","AE","7O","3C", "3O","3E","3P","2C","2O","2E","2P",
				"AC","AO","AP","KC","KO","KE","KP","JC","JO","JE","JP","QC","QO","QE","QP",
			"7E","7P","6C","6O","6E","6P","5C","5O","5E","5P","4C","4O","4E"};

			int[] vetPesos = {41,40,39,38,37,37,37,37,36,36,36,36,35,35,35,34,34,34,34,33,33,33,
				33,32,32,32,32,31,31,30,30,30,30,29,29,29,29,28,28,28};

			for (int i = 0; i < vetCartas.Length; i++)
			{
				String cartaDoVetor = vetCartas[i];
				if (cartaDoVetor.Equals(card))
				{
					return vetPesos[i];
				}
			}
			return retorno;


		}
		public static bool temRepetida(String[] cartaJogador, String[] cartaComputador)
		{

			
			for (int i = 0; i < cartaJogador.Length; i++)//compara as cartas do Computador e do Jogador
			{
				for (int j = 0; j < cartaComputador.Length; j++)
				{
					if (cartaJogador[i] == cartaComputador[j])
						return true;
					
				}

			}
			if(cartaJogador[0] == cartaJogador[1] || cartaComputador[0] == cartaComputador[1])
            {
				return true;
            }
			else if(cartaJogador[1] == cartaJogador[2] || cartaComputador[1] == cartaComputador[2])
			{
				return true;
			}else if (cartaJogador[0] == cartaJogador[2] || cartaComputador[0] == cartaComputador[2])
			{
				return true;
			}
			return false;


		}	
		public int PegarCarta()
		{

			string numCard = "";
			Console.WriteLine("Qual carta o(a) sr(a). deseja jogar?");
			Console.WriteLine("1. " + cartaJogador[0]);
			Console.WriteLine("2. " + cartaJogador[1]);
			Console.WriteLine("3. " + cartaJogador[2]);
		
			numCard = Console.ReadLine();
	
			if(numCard == "1" || numCard == "2" || numCard == "3")
            {
				return int.Parse(numCard);
            }
            else
            {
				throw new Excecoes("ERRO => Por favor, digite um número válido (1, 2 ou 3).");
			}

		}
		public bool JaJogou(int numCard, int[] jaJogouEssaCarta)
        {
			bool jaJogou = false;
			//0 = carta nao foi jogada ainda;
			//1 = carta ja foi jogada;
			if (numCard == 1 && jaJogouEssaCarta[0] == 1)
			{
				jaJogou = true;
			}
			else if (numCard == 2 && jaJogouEssaCarta[1] == 1)
			{
				jaJogou = true;
			}
			else if(numCard == 3 && jaJogouEssaCarta[2] == 1)
			{
				jaJogou = true;
			}
			else if(numCard == 1 && jaJogouEssaCarta[0] == 0)
			{
				jaJogouEssaCarta[0] = 1;
				jaJogou = false;
			}
			else if(numCard == 2 && jaJogouEssaCarta[1] == 0)
			{
				jaJogouEssaCarta[1] = 1;
				jaJogou = false;
			}
			else if(numCard == 3 && jaJogouEssaCarta[2] == 0)
			{
				jaJogouEssaCarta[2] = 1;
				jaJogou = false;
            }

			return jaJogou;


		}

		public int QuemGanhouAMao(int peso1, int peso2)
		{
			//codigos para saber quem ganhou
			if (peso1 > peso2)
			{
				Console.WriteLine("(Você ganhou essa!) \n");
				return 0; //jogador ganhou
			}
			else if (peso1 < peso2)
			{
				Console.WriteLine("(Computador ganhou essa.) \n");
				return 1; //comp ganhou
			}
			else
			{
				Console.WriteLine("(Empatou essa.) \n");
				return 2; //empate
			}
		}

		public bool AcabouOJogo(bool jogadorVenceu)
		{
			bool acabou = false;
			if (jogadorVenceu)
			{
				pontos.setpontosJogador(2);
				Console.WriteLine("->Pontos jogador: " + pontos.getpontosJogador());
				Console.WriteLine("->Pontos computador: " + pontos.getpontosComputador());
				acabou = pontos.AcabouOJogo();
			}
			else if (!jogadorVenceu)
			{
				pontos.setpontosComputador(2);
				Console.WriteLine("->Pontos jogador: " + pontos.getpontosJogador());
				Console.WriteLine("->Pontos computador: " + pontos.getpontosComputador());
				acabou = pontos.AcabouOJogo();
			}
			else
			{
				throw new Excecoes("Erro nos pontos");
			}
			return acabou;

		}


	}

}
