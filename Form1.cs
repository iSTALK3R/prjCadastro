using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjCadastro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string ValidarCPF(string sCPF)
        {
            // Criar variavel do tipo array
            int[] arrayCPF = new int[9];
            // Criar variavel do tipo array para armazenar 10 valores
            int[] arrayCPF2 = new int[10];
            // Criar variavel para armazenar o cpf tratado
            string sCPFTratado = "";
            // Criar variavel para armazenar o valor da soma
            int iValorSoma = 0;
            // Criar variavel para armazwnar o valor da soma do segundo digito
            int iValorSoma2 = 0;
            // Criar variavel para calcular a multiplicação
            int iValorMult = 0;
            // Criar variavel para calcular a multiplicação do segundo digito
            int iValorMult2 = 0;
            // Criar variavel para armazenar o valor do primeiro digito
            int iPrimeiroDigito = 0;
            // Criar variavel para armazenar o valor do segundo digito
            int iSegundoDigito = 0;
            // Variavel para armazenar o penultimo digito digitado
            int iPrimeiroValor = 0;
            // Variavel para armazenar o ultimo digito digitado
            int iSegundoValor = 0;


            // Trata a string do CPF
            sCPFTratado = sCPF.Replace(".", "").Replace("-", "").Replace("/", "");

            // Criar um For para preencher o array
            for (int i = 0; i < 9; i++)
            {
                // Passando o valor da variavel para o array
                arrayCPF[i] = Convert.ToInt32(sCPFTratado.Substring(i, 1)) * (10 - i);
            }

            // Fazer for para somar os valores do array
            for (int i = 0; i < 9; i++)
            {
                // Somar os valores e passar para a variavel
                iValorSoma += arrayCPF[i];
            }

            // Calcular a multiplicação por 10
            iValorMult = iValorSoma * 10;
            // Armazenar o valor do resto da divisão
            iPrimeiroDigito = iValorMult % 11;

            // Criar for para preencher o Array com 10 valores
            for (int i = 0; i < 10; i++)
            {
                arrayCPF2[i] = Convert.ToInt32(sCPFTratado.Substring(i, 1)) * (11 - i);
            }

            // Criar for para somar os valores do segundo digito
            for (int i = 0; i < 10; i++)
            {
                iValorSoma2 += arrayCPF2[i];
            }

            // Calculando a multiplicação por 10
            iValorMult2 = iValorSoma2 * 10;
            // Armazenano o resto da divisão
            iSegundoDigito = iValorMult2 % 11;

            iPrimeiroValor = Convert.ToInt32(sCPFTratado.Substring(9, 1));
            iSegundoValor = Convert.ToInt32(sCPFTratado.Substring(10, 1));


            if (iPrimeiroValor == iPrimeiroDigito && iSegundoValor == iSegundoDigito)
            {
                return "CPF Valido";

            }
            else
            {
                return "CPF Invalido";
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ValidarCPF(txtCPF.Text).ToString());
        }
    }
}
