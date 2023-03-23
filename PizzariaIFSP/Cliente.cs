using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaIFSP
{
    internal class Cliente
    {
        
        private string Nome;
        private string Telefone;
        private string Email;
        private DateTime DatNasc;

        public Cliente(string nome, string tel)
        {
            Nome = nome;
            Telefone = tel; 
        }
        public Cliente(string nome, string tel = "", string email = "", DateTime datNasc = new DateTime())
        {
            Nome = nome;
            Telefone = tel;
            Email = email;
            DatNasc = datNasc;
        }

        public String telefone
        {
            get { return Telefone; }
        }

        public void Set_atritutes(string nome = "", string telefone = "", string email = "", DateTime datNasc = new DateTime())
        {
            if (nome == "")                     nome    = this.Nome;
            if (telefone == "")                 nome    = this.Telefone;
            if (email == "")                    nome    = this.Email;
            if (datNasc ==  new DateTime())     datNasc = this.DatNasc;

            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.DatNasc = datNasc;
        }



        public string get_nome()
        {
            return this.Nome;
        }

        public override string ToString()
        {
            string text = "\n";
            if (Nome != "")                     text += "\n\tNOME:       " + Nome;
            if (Telefone != "")                 text += "\n\tTELEFONE:   " + Telefone;
            if (Email != "")                    text += "\n\tEMAIL:      " + Email;
            if (DatNasc != new DateTime())      text += "\n\tNASCIMENTO: " + DatNasc.ToShortDateString();
            text += "\n";
            return text;
        }
    }
}
