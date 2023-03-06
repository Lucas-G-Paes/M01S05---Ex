using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1S3_SistemaBanco
{
    public class PessoaFisica : Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }


        public int Idade { get {return (int)(Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.25)); 
        } private set {} }

        public PessoaFisica()
        {

        }

        public PessoaFisica(string nome, string cpf, DateTime dtNascimento,
        string email, string telefone, string end, int numeroConta)
        : base (email, telefone, end, numeroConta) 
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dtNascimento;
        }

        public override string ResumoCliente()
        {
           return $"{base.ResumoCliente()} |   {Nome}   |   {CPF}   |";
        }

        public bool EhMaior()
        {
            return Idade >= 18;
        }
    }
}